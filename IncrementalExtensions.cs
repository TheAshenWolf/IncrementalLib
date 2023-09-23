namespace IncrementalLib
{
  /// <summary>
  /// Extension methods for the Incremental class.
  /// </summary>
  public static class IncrementalExtensions
  {
    /// <summary>
    /// Checks if the Incremental is zero.
    /// </summary>
    public static bool IsZero(this Incremental value)
    {
      return value.Value == 0;
    }
  }
}