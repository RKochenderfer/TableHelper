namespace TableHelper.Models.Generators.Place;

public class Hazard
{
    public required string Type { get; init; }
    public required string[] SpecificExamples { get; init; }
    public required string[] PossibleDangers { get; init; }
}