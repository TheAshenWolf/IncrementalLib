namespace IncrementalLib
{
  public partial class Incremental
  {
    /// <summary>
    /// Adds two Incrementals together, returning a new Incremental.
    /// (Does not modify the original Incrementals, creates a new one)
    /// </summary>
    /// <returns>New incremental with the result</returns>
    public static Incremental operator +(Incremental a, Incremental b)
    {
      Incremental result = new Incremental(a.Value, a.Exponent);
      result.Add(b);
      return result;
    }
    
    /// <summary>
    /// Adds a double <paramref name="b"/> to an Incremental <paramref name="a"/>.
    /// (Does not modify the original Incrementals, creates a new one)
    /// </summary>
    /// <returns>New Incremental with the result</returns>
    public static Incremental operator +(Incremental a, double b)
    {
      Incremental result = new Incremental(a.Value, a.Exponent);
      result.Add(b);
      return result;
    }

    /// <summary>
    /// Adds a double <paramref name="a"/> and an Incremental <paramref name="b"/>.
    /// (Does not modify the original Incremental, creates a new one)
    /// </summary>
    /// <returns>New Incremental with the result</returns>
    public static Incremental operator +(double a, Incremental b)
    {
      Incremental result = new Incremental(b.Value, b.Exponent);
      result.Add(a);
      return result;
    }
    
    /// <summary>
    /// Adds an integer <paramref name="b"/> to an Incremental <paramref name="a"/>.
    /// (Does not modify the original Incremental, creates a new one)
    /// </summary>
    /// <returns>New Incremental with the result</returns>
    public static Incremental operator +(Incremental a, int b)
    {
      Incremental result = new Incremental(a.Value, a.Exponent);
      result.Add(b);
      return result;
    }

    /// <summary>
    /// Adds an integer <paramref name="a"/> and an Incremental <paramref name="b"/>.
    /// (Does not modify the original Incremental, creates a new one)
    /// </summary>
    /// <returns>New Incremental with the result</returns>
    public static Incremental operator +(int a, Incremental b)
    {
      Incremental result = new Incremental(b.Value, b.Exponent);
      result.Add(a);
      return result;
    }
    
    /// <summary>
    /// Subtracts <paramref name="b"/> Incremental from <paramref name="a"/> Incremental.
    /// (Does not modify the original Incrementals, creates a new one)
    /// </summary>
    /// <returns>New incremental with the result</returns>
    public static Incremental operator -(Incremental a, Incremental b)
    {
      Incremental result = new Incremental(a.Value, a.Exponent);
      result.Subtract(b);
      return result;
    }

    /// <summary>
    /// Multiplies two Incrementals together, returning a new Incremental.
    /// (Does not modify the original Incrementals, creates a new one)
    /// </summary>
    /// <returns>New Incremental with the result</returns>
    public static Incremental operator *(Incremental a, Incremental b)
    {
      Incremental result = new Incremental(a.Value, a.Exponent);
      result.Multiply(b);
      return result;
    }
    
    /// <summary>
    /// Multiplies Incremental <paramref name="a"/> by a double <paramref name="b"/>.
    /// (Does not modify the original Incremental, creates a new one)
    /// </summary>
    /// <returns>New Incremental with the result</returns>
    public static Incremental operator *(Incremental a, double b)
    {
      Incremental result = new Incremental(a.Value, a.Exponent);
      result.Multiply(b);
      return result;
    }

    /// <summary>
    /// Multiplies double <paramref name="a"/> and an Incremental <paramref name="b"/>.
    /// (Does not modify the original Incremental, creates a new one)
    /// </summary>
    /// <returns>New Incremental with the result</returns>
    public static Incremental operator *(double a, Incremental b)
    {
      Incremental result = new Incremental(b.Value, b.Exponent);
      result.Multiply(a);
      return result;
    }

    /// <summary>
    /// Multiplies Incremental <paramref name="a"/> by an integer <paramref name="b"/>.
    /// (Does not modify the original Incremental, creates a new one)
    /// </summary>
    /// <returns>New Incremental with the result</returns>
    public static Incremental operator *(Incremental a, int b)
    {
      Incremental result = new Incremental(a.Value, a.Exponent);
      result.Multiply(b);
      return result;
    }

    /// <summary>
    /// Multiplies integer <paramref name="a"/> and an Incremental <paramref name="b"/>.
    /// (Does not modify the original Incremental, creates a new one)
    /// </summary>
    /// <returns>New Incremental with the result</returns>
    public static Incremental operator *(int a, Incremental b)
    {
      Incremental result = new Incremental(b.Value, b.Exponent);
      result.Multiply(a);
      return result;
    }
    
    /// <summary>
    /// Divides Incremental <paramref name="a"/> by an Incremental <paramref name="b"/>.
    /// (Does not modify the original Incrementals, creates a new one)
    /// </summary>
    /// <returns>New Incremental with the result</returns>
    public static Incremental operator /(Incremental a, Incremental b)
    {
      Incremental result = new Incremental(a.Value, a.Exponent);
      result.Divide(b);
      return result;
    }
    
    /// <summary>
    /// Divides Incremental <paramref name="a"/> by a double <paramref name="b"/>.
    /// (Does not modify the original Incremental, creates a new one)
    /// </summary>
    /// <returns>New Incremental with the result</returns>
    public static Incremental operator /(Incremental a, double b)
    {
      Incremental result = new Incremental(a.Value, a.Exponent);
      result.Divide(b);
      return result;
    }

    /// <summary>
    /// Divides Incremental <paramref name="a"/> by an int <paramref name="b"/>.
    /// This is not an integer division.
    /// (Does not modify the original Incremental, creates a new one)
    /// </summary>
    /// <returns>New Incremental with the result</returns>
    public static Incremental operator /(Incremental a, int b)
    {
      Incremental result = new Incremental(a.Value, a.Exponent);
      result.Divide(b);
      return result;
    }

    /// <summary>
    /// Multiplies Incremental by an <paramref name="other"/> Incremental.
    /// (Modifies the original Incremental)
    /// </summary>
    public void Multiply(Incremental other)
    {
      Unpack();
      other.Unpack();

      Value *= other.Value;
      Exponent += other.Exponent;
      Normalize();
    }

    /// <summary>
    /// Multiplies Incremental with the <paramref name="other"/> Incremental.
    /// (Does not modify the original Incrementals, creates a new one)
    /// </summary>
    public void Multiply(double other, int exponent = 0)
    {
      Multiply(new Incremental(other, exponent));
    }

    /// <summary>
    /// Divides Incremental by an <paramref name="other"/> Incremental.
    /// (Modifies the original Incremental)
    /// </summary>
    public void Divide(Incremental other)
    {
      Unpack();
      other.Unpack();

      Value /= other.Value;
      Exponent -= other.Exponent;
      Normalize();
    }

    /// <summary>
    /// Divides Incremental by a double <paramref name="other"/>.
    /// (Modifies the original Incremental)
    /// </summary>
    public void Divide(double other, int exponent = 0)
    {
      Divide(new Incremental(other, exponent));
    }


    /// <summary>
    /// Adds <paramref name="other"/> Incremental to this one.
    /// (Modifies the original Incremental)
    /// </summary>
    public void Add(Incremental other)
    {
      Unpack();
      other.Unpack();

      Align(other);
      Value += other.Value;
      Normalize();
    }

    /// <summary>
    /// Adds <paramref name="other"/> double to this Incremental.
    /// (Modifies the original Incremental)
    /// </summary>
    public void Add(double other, int exponent = 0)
    {
      Add(new Incremental(other, exponent));
    }

    /// <summary>
    /// Subtracts <paramref name="other"/> Incremental from this one.
    /// (Modifies the original Incremental)
    /// </summary>
    public void Subtract(Incremental other)
    {
      Unpack();
      other.Unpack();

      Align(other);
      Value -= other.Value;
      Normalize();
    }

    /// <summary>
    /// Returns the remainder of the division of Incremental <paramref name="a"/> by an int <paramref name="b"/>.
    /// Converts the <see cref="Value"/> to an integer before performing the operation.
    /// </summary>
    public static int operator %(Incremental a, int b)
    {
      return (int)a.Value % b;
    }

    /// <summary>
    /// Increments the Incremental by 1.
    /// </summary>
    public static Incremental operator ++(Incremental a)
    {
      a.Add(new Incremental(1));
      return a;
    }

    /// <summary>
    /// Returns the Incremental.
    /// </summary>
    public static Incremental operator +(Incremental a)
    {
      return a;
    }


    /// <summary>
    /// Negates the Incremental.
    /// </summary>
    public static Incremental operator -(Incremental a)
    {
      a.Negative = !a.Negative;
      return a;
    }
  }
}