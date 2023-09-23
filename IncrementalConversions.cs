namespace IncrementalLib
{
  public partial class Incremental
  {
    /// <summary>
    /// Implicitly converts a double into an Incremental.
    /// </summary>
    public static implicit operator Incremental(double value)
    {
      return new Incremental(value);
    }
    
    /// <summary>
    /// Implicitly converts an int into an Incremental.
    /// </summary>
    public static implicit operator Incremental(int value)
    {
      return new Incremental(value);
    }
  }
}