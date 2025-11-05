using TableHelper.Models.Generators;
using TableHelper.Models.Npc;

namespace TableHelper.Models.Responses;

public class AdventureSeedGenerateResponse : GenerateResponse
{
    public IEnumerable<AdventureSeed> AdventureSeeds { get; }

    public AdventureSeedGenerateResponse(bool isSuccessful, string? errorMessage, IEnumerable<AdventureSeed> adventureSeeds) : base(isSuccessful, errorMessage)
    {
        AdventureSeeds = adventureSeeds;
    }

    public static AdventureSeedGenerateResponse Success(IEnumerable<AdventureSeed> adventureSeeds)
    {
        ArgumentNullException.ThrowIfNull(adventureSeeds);

        return new AdventureSeedGenerateResponse(isSuccessful: true, errorMessage: null,
            adventureSeeds: adventureSeeds);
    }

    public static AdventureSeedGenerateResponse Fail(string errorMessage)
    {
        return new AdventureSeedGenerateResponse(isSuccessful: false, errorMessage: errorMessage,
            adventureSeeds: new List<AdventureSeed>());
    }
}