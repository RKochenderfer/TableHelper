namespace TableHelper.Models.Npc;

public class NameOption
{
    /// <summary>
    /// The inclusive start of the roll range
    /// </summary>
    public required int RangeStart { get; init; }
    /// <summary>
    /// The inclusive end of the roll range
    /// </summary>
    public required int RangeEnd { get; init; }
    /// <summary>
    /// The male sounding name
    /// </summary>
    public required string Male  { get; init; }
    /// <summary>
    /// The female sounding name
    /// </summary>
    public required string Female { get; init; }
    public required string Surname { get; init; }
}