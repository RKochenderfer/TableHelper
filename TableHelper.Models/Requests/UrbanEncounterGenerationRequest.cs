namespace TableHelper.Models.Requests;

public class UrbanEncounterGenerationRequest : IRequest
{
    public int EncountersToGenerate { get; init; }

    public static UrbanEncounterGenerationRequest From(int encountersToGenerate)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(encountersToGenerate);

        return new UrbanEncounterGenerationRequest
        {
            EncountersToGenerate = encountersToGenerate
        };
    }

    public bool Validate()
    {
        return EncountersToGenerate > 0;
    }
}