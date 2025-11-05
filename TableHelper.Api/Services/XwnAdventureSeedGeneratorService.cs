using TableHelper.Infrastructure.Repositories;
using TableHelper.Models;
using TableHelper.Models.Generators;
using TableHelper.Models.Npc;
using TableHelper.Models.Requests;

namespace TableHelper.Api.Services;

public class XwnAdventureSeedGeneratorService(
    IAdventureSeedGeneratorRepository adventureSeedGeneratorRepository,
    IRandomizer<string> randomizer)
{
    public async Task<IReadOnlyList<AdventureSeed>> GenerateAdventureSeeds(AdventureSeedGenerateRequest request)
    {
        var generatorData = await adventureSeedGeneratorRepository.GetAdventureSeeds();
        var randomEntries = randomizer.GetRandomEntries(generatorData.Seeds.ToList(), request.NumberOfSeeds);
        
        return randomEntries.Select(e => new AdventureSeed(e)).ToList();
    }
}