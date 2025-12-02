using TableHelper.Infrastructure.Services;
using TableHelper.Models.Generators;

namespace TableHelper.Infrastructure.Repositories.Generators;

public class JsonAdventureSeedGeneratorRepository(JsonFileDeserializer<AdventureSeedGeneratorData> deserializer)
    : IAdventureSeedGeneratorRepository
{
    private const string AdventureSeedGeneratorDataPath = "data/SWN/adventureSeedGenerator.json";

    public async Task<AdventureSeedGeneratorData> GetAdventureSeeds()
    {
        var jsonData = await deserializer.ReadJsonFile(AdventureSeedGeneratorDataPath);
        return jsonData ?? throw new Exception("JSON data not found");
    }
}