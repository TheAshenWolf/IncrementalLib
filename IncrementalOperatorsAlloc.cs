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
    /// Adds an integer <paramref name="b"/> to an Incremental <paramref name="a"/>.
    /// (Does not modify the original Incrementals, creates a new one)
    /// </summary>
    /// <returns>New Incremental with the result</returns>
    public static Incremental operator +(Incremental a, int b)
    {
      Incremental result = new Incremental(a.Value, a.Exponent);
      result.Add(b);
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
    
    
    
    
  }
}