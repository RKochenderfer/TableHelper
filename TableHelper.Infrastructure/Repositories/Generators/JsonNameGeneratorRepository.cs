using TableHelper.Infrastructure.Services;
using TableHelper.Models.Generators.Npc;

namespace TableHelper.Infrastructure.Repositories.Generators;

public class JsonNameGeneratorRepository(JsonFileDeserializer<NpcGeneratorData> deserializer) : INpcGeneratorRepository
{
    private const string NpcGeneratorDataPath = "data/SWN/npcGenerator.json";

    public Task<NpcGeneratorData> GetAllGeneratorData()
    {
        throw new NotImplementedException();
    }

    public async Task<NpcNameOptions> GetAllNameOptions()
    {
        var jsonData = await deserializer.ReadJsonFile(NpcGeneratorDataPath);
        return jsonData == null ? throw new Exception("Json data not found") : jsonData.NameOptions;
    }

    public async Task<NpcMakeupOptions> GetAllMakeupOptions()
    {
        var jsonData = await deserializer.ReadJsonFile(NpcGeneratorDataPath);
        return jsonData == null ? throw new Exception("Json data not found") : jsonData.NpcMakeupOptions;
    }
}