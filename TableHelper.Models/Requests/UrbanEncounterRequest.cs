namespace TableHelper.Models.Requests;

public class UrbanEncounterRequest : IRequest
{
    public int EncountersToGenerate { get; init; }

    public static UrbanEncounterRequest From(int encountersToGenerate)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(encountersToGenerate);

        return new UrbanEncounterRequest
        {
            EncountersToGenerate = encountersToGenerate
        };
    }

    public bool Validate()
    {
        return EncountersToGenerate > 0;
    }
}