namespace TableHelper.Models.Requests;

public class WildernessEncounterGeneratorRequest : IRequest
{
    public int EncountersToGenerate { get; init; }

    public static WildernessEncounterGeneratorRequest From(int encountersToGenerate)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(encountersToGenerate);

        return new WildernessEncounterGeneratorRequest
        {
            EncountersToGenerate = encountersToGenerate
        };
    }

    public bool Validate()
    {
        return EncountersToGenerate > 0;
    }
}