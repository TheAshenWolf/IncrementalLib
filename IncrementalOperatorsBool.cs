using System;

namespace IncrementalLib
{
  public partial class Incremental
  {
    /// <summary>
    /// Equals operator for Incremental.
    /// </summary>
    public bool Equals(Incremental other)
    {
      return Value.Equals(other.Value) && Exponent == other.Exponent && Negative == other.Negative;
    }

    /// <inheritdoc />
    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((Incremental)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
      return HashCode.Combine(Value, Exponent, Negative);
    }


    /// <summary>
    /// Returns true if the two Incrementals are equal.
    /// </summary>
    public static bool operator ==(Incremental a, Incremental b)
    {
      if (ReferenceEquals(a, b)) return true;
      if (a is null || b is null) return false;

      a.Normalize();
      b.Normalize();

      return a.Value.Equals(b.Value) && a.Exponent == b.Exponent && a.Negative == b.Negative;
    }
    
    /// <summary>
    /// Returns true if the two Incrementals are not equal.
    /// </summary>
    public static bool operator !=(Incremental a, Incremental b)
    {
      return !(a == b);
    }

    /// <summary>
    /// Returns true if <paramref name="a"/> is greater than <paramref name="b"/>.
    /// </summary>
    public static bool operator >(Incremental a, Incremental b)
    {
      if (a is null || b is null) return false;

      a.Normalize();
      b.Normalize();

      // Simple comparison for different signs
      if (a.Negative && !b.Negative) return false;
      if (!a.Negative && b.Negative) return true;

      bool negative = a.Negative && b.Negative;
      
      if (a.Exponent > b.Exponent) return !negative;
      if (a.Exponent < b.Exponent) return negative;
      
      return negative ? a.Value < b.Value : a.Value > b.Value;
    }
    
    /// <summary>
    /// Returns true if <paramref name="a"/> is less than <paramref name="b"/>.
    /// </summary>
    public static bool operator <(Incremental a, Incremental b)
    {
      return a != b && !(a > b);
    }
    
    /// <summary>
    /// Returns true if <paramref name="a"/> is greater than or equal to <paramref name="b"/>.
    /// </summary>
    public static bool operator >=(Incremental a, Incremental b)
    {
      return a == b || a > b;
    }

    /// <summary>
    /// Returns true if <paramref name="a"/> is less than or equal to <paramref name="b"/>.
    /// </summary>
    public static bool operator <=(Incremental a, Incremental b)
    {
      return a == b || a < b;
    }
  }
}