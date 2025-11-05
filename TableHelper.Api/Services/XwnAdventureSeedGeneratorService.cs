using TableHelper.Infrastructure.Repositories;
using TableHelper.Models;
using TableHelper.Models.Npc;
using TableHelper.Models.Requests;

namespace TableHelper.Api.Services;

public class XwnAdventureSeedGeneratorService(
    IAdventureSeedGeneratorRepository adventureSeedGeneratorRepository,
    Random rnd)
{
    public async Task<IReadOnlyList<AdventureSeed>> GenerateAdventureSeeds(AdventureSeedGenerateRequest request)
    {
        var generatorData = await adventureSeedGeneratorRepository.GetAdventureSeeds();

        var seeds = new List<AdventureSeed>();
        while (seeds.Count != request.NumberOfSeeds)
        {
            var index = rnd.Next(0, generatorData.Seeds.Length);
            var seed = generatorData.Seeds[index];
            seeds.Add(new AdventureSeed(seed));
        }

        return seeds;
    }
}