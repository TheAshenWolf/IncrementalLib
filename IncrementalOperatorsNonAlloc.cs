using System;

namespace IncrementalLib
{
  public partial class Incremental
  {
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
    public void Multiply(double other)
    {
      Unpack();
      
      Value *= other;
      Normalize();
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
    public void Divide(double other)
    {
      Unpack();
      
      Value /= other;
      Normalize();
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
    public void Add(double other)
    {
      Unpack();
      
      Value += other;
      Normalize();
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
  }
}