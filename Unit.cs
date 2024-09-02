namespace IncrementalLib
{
  /// <summary>
  /// Struct containing a unit definition
  /// </summary>
  public readonly struct Unit
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="full">Full name of the unit</param>
    /// <param name="abbrev"></param>
    public Unit(string full, string abbrev)
    {
      Full = full;
      Abbrev = abbrev;
    }

    /// <summary>
    /// Full name of the unit
    /// </summary>
    public string Full { get; }

    /// <summary>
    /// Abbreviation of the unit
    /// </summary>
    public string Abbrev { get; }

    public override string ToString()
    {
      return ToString(DisplaySetting.Abbreviation);
    }

    /// <summary>
    /// Returns a string representation of the unit
    /// </summary>
    public string ToString(DisplaySetting displaySetting)
    {
      return displaySetting switch
      {
        DisplaySetting.Abbreviation => Abbrev,
        DisplaySetting.FullName => Full,
        DisplaySetting.Scientific => "",
        _ => Abbrev
      };
    }
  }
}