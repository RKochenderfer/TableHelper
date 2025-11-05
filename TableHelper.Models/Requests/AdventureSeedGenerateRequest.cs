namespace TableHelper.Models.Requests;

public class AdventureSeedGenerateRequest : IRequest
{
    public int NumberOfSeeds { get; init; }


    public static AdventureSeedGenerateRequest From(int numberOfSeeds)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberOfSeeds, "numberOfSeeds");
        return new AdventureSeedGenerateRequest { NumberOfSeeds = numberOfSeeds };
    }

    public bool Validate()
    {
        return NumberOfSeeds > 0;
    }
}