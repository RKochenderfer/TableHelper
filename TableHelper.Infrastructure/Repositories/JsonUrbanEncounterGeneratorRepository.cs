using TableHelper.Infrastructure.Services;
using TableHelper.Models.Generators;

namespace TableHelper.Infrastructure.Repositories;

public class JsonUrbanEncounterGeneratorRepository(JsonFileDeserializer<UrbanEncountersGeneratorData> deserializer) : IUrbanEncounterGeneratorRepository
{
    private const string UrbanEncounterGeneratorDataPath = "data/SWN/urbanEncounters.json";
    
    public async Task<UrbanEncountersGeneratorData> GetUrbanEncounterData()
    {
        var jsonData = await deserializer.ReadJsonFile(UrbanEncounterGeneratorDataPath);
        return jsonData ?? throw new Exception("JSON data not found");
    }
}