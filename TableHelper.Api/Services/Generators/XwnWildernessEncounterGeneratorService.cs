using TableHelper.Api.Services.Randomizer;
using TableHelper.Infrastructure.Repositories;
using TableHelper.Models;
using TableHelper.Models.Requests;

namespace TableHelper.Api.Services.Generators;

public class XwnWildernessEncounterGeneratorService(IWildernessEncounterGeneratorRepository repository, ISetRandomizer<string> randomizer)
{
    public async Task<IReadOnlyList<WildernessEncounter>> GenerateWildernessEncounters(WildernessEncounterGeneratorRequest request)
    {
        var generatorData = await repository.GetWildernessEncounterData();

        var encounters = new List<WildernessEncounter>();
        while (encounters.Count != request.EncountersToGenerate)
        {
            var weatherAndLighting = randomizer.GetRandomElement(generatorData.WeatherAndLighting);
            var basicNatureOfTheEncounter = randomizer.GetRandomElement(generatorData.BasicNatureOfTheEncounter);
            var typeOfFriendlyCreatures = randomizer.GetRandomElement(generatorData.TypesOfFriendlyCreatures);
            var initialEncounterRange = randomizer.GetRandomElement(generatorData.InitialEncounterRange);
            var typesOfHostileCreatures = randomizer.GetRandomElement(generatorData.TypesOfHostileCreatures);
            var specificNearbyFeatureOfRelevance = randomizer.GetRandomElement(generatorData.SpecificNearbyFeatureOfRelevance);
            var encounter = new WildernessEncounter(weatherAndLighting, basicNatureOfTheEncounter, typeOfFriendlyCreatures,
                initialEncounterRange, typesOfHostileCreatures, specificNearbyFeatureOfRelevance);
            
            encounters.Add(encounter);
        }
        
        return encounters;
    }
}