# IncrementalLib

---

Library for handling large (insanely large) numbers for Unity.
Inspired by [FredericRezeau's idle-bignum](https://github.com/FredericRezeau/idle-bignum).

## About the Incremental Type

The incremental consists of two important parts. The `Value` and the `Exponent`.
It is important to say, however, that "Exponent" does not represent `Value ^ Exponent`, but rather `Value * 10^Exponent`.
This means that value 200 with exponent 0 does not represent 1 (as in `200^0`), but 200 itself, as in `200 * 10^0 = 200`.

All of the provided methods are documented in the code using the XML documentation, so feel free to check it directly in the code.
If you have a smart IDE, you should be able to see the documentation by hovering over the method.

### Precision
The value I have chosen for the built in precision is 15. What this means - if your currency is 10^21 and you are subtracting 10^3, 
your currency will not be affected. If you need more precision (you shouldn't, but that's up to you), you can change the constant `MAX_MAGNITUDE_DIFFERENCE` in `Incremental.cs`

### Construction

In the constructor, you can pass the value and the exponent, or you can leave them out and you will get a zero incremental.
It also accepts the `LargeNumbers` and `NumberAbbrev` enums in the exponent parameter.
```csharp
    Incremental zeroIncremental = new Incremental(); // 0

    Incremental doubleDoubleIncremental = new Incremental(1, 3); // 1,000
    
    Incremental largeIncremental = new Incremental(1, LargeNumbers.Thousand); // 1,000
    
    Incremental numberAbbrevIncremental = new Incremental(1, NumberAbbrev.k); // 1,000
```

### Mathematical operations

There are two ways of running these operations. The first one is by using the operator overloads, and the second one is by using the methods.

#### Operators

Basic operators (+, -, *, /) are overloaded, and you can use them as you would with any other number. The operators accept `Incremental`, `int` and `double`.

```csharp
    Incremental a = new Incremental(1, 3); // 1,000
    Incremental b = new Incremental(2, 3); // 2,000

    Incremental sum = a + b; // 3,000
    Incremental difference = a - b; // -1,000
    Incremental product = a * b; // 2,000,000
    Incremental quotient = a / b; // 0.5
```

#### Methods

Methods, unlike operators, do not create a new incremental. They modify the existing one.
This has the added benefit of not creating a new object, thus reducing the amount of garbage created.

```csharp
    Incremental a = new Incremental(1, 3); // 1,000
    Incremental b = new Incremental(2, 3); // 2,000

    a.Add(b); // 3,000
    a.Subtract(b); // 1,000
    a.Multiply(b); // 2,000,000
    a.Divide(b); // 1,000
```

#### Special cases

Modulo returns an integer. For this reason it only exists in the operator `%` form even though it does not create any garbage.


### Comparisons

Incrementals support all comparison operations `==, !=, >, <, >=, <=`.

```csharp
    Incremental a = new Incremental(1, 3); // 1,000
    Incremental b = new Incremental(2, 3); // 2,000

    bool equal = a == b; // false
    bool notEqual = a != b; // true
    bool greater = a > b; // false
    bool less = a < b; // true
    bool greaterOrEqual = a >= b; // false
    bool lessOrEqual = a <= b; // true
```

### Conversions

While Incrementals themselves cannot be converted into other types due to possible overflow, `double` and `int` have implicit conversions.

```csharp
    double doubleValue = doubleValue; // 1000.0
    int intValue = intValue; // 1000
    
    Incremental fromDouble = doubleValue; // Essentially new Incremental(doubleValue)
    Incremental fromInt = intValue; // Essentially new Incremental(intValue)
```

### Formatting

For basic use, you can use the `ToString()` method. It should be enough for most cases.
You may override the `DefaultDisplaySetting` enum within `Incremental.cs` to change the default formatting.
You can also use the `ToString(DisplaySetting)` override.

All abbreviations and names are unique up to 10^333. After that, the number will be displayed using the scientific notation.
If you want to know how this naming works, please, see [this wikipedia page](https://en.wikipedia.org/wiki/Names_of_large_numbers).


The returned string will be formatted as follows:

- `Abbreviation` - Abbreviation of the number (k, M, B, T, ...)
```csharp
    Incremental incremental = new Incremental(1, 3); // 1,000
    string formatted = incremental.ToString(); // 1 k
```

- `FullName` - Full name of the number (Thousand, Million, Billion, Trillion, ...)
```csharp
    Incremental incremental = new Incremental(1, 3); // 1,000
    string formatted = incremental.ToString(DisplaySetting.FullName); // 1 Thousand
```

- `Scientific` - Scientific notation
```csharp
    Incremental incremental = new Incremental(1, 3); // 1,000
    string formatted = incremental.ToString(DisplaySetting.Scientific); // 1e3
```

### Internal methods

There are a few internal methods that you can use, but they are not recommended for general use.

`Normalize()`  
Ran before comparisons and after every operation and constructor. Normalizes the Incremental to values between 0 - 999 and sets the exponent to the appropriate value. 
If the value is negative, sets the `Negative` flag.

`Align()`  
Ran before every operation. Aligns the exponents of two Incrementals. This is necessary for operations to work correctly.

`Unpack()`  
Applies the `Negative` flag onto the value. This is required for some operations to work correctly.

`IsZero()`  
Returns true if the Incremental is zero.

### Accompanying types

There are several other types which come with the Incremental type.

`DisplaySetting` - an Enum used to represent which way the Incremental should be displayed.

`LargeNumbers` - an Enum used to represent large number texts (Thousand, Million, Billion, ...)

`NumberAbbrev` - an Enum used to represent number abbreviations (k, M, B, ...)

`Unit` - a struct used to represent the value and the exponent of the Incremental.

## Usage in your project

- Download a copy of the repository and put this folder somewhere in your project. (I would recommend a `Assets/Plugins/IncrementalLib` folder)

- For your currency type, use the `Incremental` type.

```csharp
using IncrementalLib;

...
    
public Incremental wallet = new Incremental();
```

- You can now use the Incremental type as you would any other number.
Here are some examples:

```csharp
public void AddMoney(double amount)
{
    wallet.Add(amount);
}

public bool CanAffordUpgrade(Incremental cost)
{
    return wallet >= cost;
}

public string GetWalletString()
{
    return wallet.ToString();
}
```

### Final notes

Thank you for trying out this lib. If you find any bugs / issues, feel free to open an issue on the repository.  
You do not have to credit me if you use this lib in your project, but it would be cool if you did :>

