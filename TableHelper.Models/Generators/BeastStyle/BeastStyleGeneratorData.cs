namespace TableHelper.Models.Generators.BeastStyle;

public class BeastStyleGeneratorData
{
    public required string[] BasicAnimalFeature { get; init; }
    public required BodyTrait[] BodyTraits { get; init; }
    public required BehavioralTraits[] BehavioralTraits { get; init; }
    public required string[] HarmfulDischarge { get; init; }
    public required Poison[] Poisons { get; init; }
}