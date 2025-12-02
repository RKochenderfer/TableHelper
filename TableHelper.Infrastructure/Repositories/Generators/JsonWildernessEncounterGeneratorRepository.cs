using TableHelper.Infrastructure.Services;
using TableHelper.Models.Generators;

namespace TableHelper.Infrastructure.Repositories.Generators;

public class JsonWildernessEncounterGeneratorRepository(
    JsonFileDeserializer<WildernessEncountersGeneratorData> deserializer) : IWildernessEncounterGeneratorRepository
{
    private const string WildernessEncounterGeneratorDataPath = "data/SWN/wildernessEncounters.json";

    public async Task<WildernessEncountersGeneratorData> GetWildernessEncounterData()
    {
        var jsonData = await deserializer.ReadJsonFile(WildernessEncounterGeneratorDataPath);
        return jsonData ?? throw new Exception("JSON data not found");
    }
}