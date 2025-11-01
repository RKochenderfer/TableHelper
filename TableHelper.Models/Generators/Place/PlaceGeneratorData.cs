namespace TableHelper.Models.Generators.Place;

public class PlaceGeneratorData
{
    public required string[] Rewards { get; init; }
    public required string[] CivilizedOngoings { get; init; }
    public required string[] WildernessOngoings { get; init; }
    public required Hazard[] Hazards { get; init; }
}