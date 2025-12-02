using TableHelper.Api.Services.Randomizer;
using TableHelper.Infrastructure.Repositories;
using TableHelper.Infrastructure.Repositories.Generators;
using TableHelper.Models;
using TableHelper.Models.Requests;

namespace TableHelper.Api.Services.Generators;

public class XwnAdventureSeedGeneratorService(
    IAdventureSeedGeneratorRepository adventureSeedGeneratorRepository,
    ISetRandomizer<string> setRandomizer)
{
    public async Task<IReadOnlyList<AdventureSeed>> GenerateAdventureSeeds(AdventureSeedGenerateRequest request)
    {
        var generatorData = await adventureSeedGeneratorRepository.GetAdventureSeeds();
        var randomEntries = setRandomizer.GetRandomElementSet(generatorData.Seeds, request.NumberOfSeeds);
        
        return randomEntries.Select(e => new AdventureSeed(e)).ToList();
    }
}