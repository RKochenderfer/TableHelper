using System.Text.Json;
using TableHelper.Models.Generators.Npc;

namespace TableHelper.Infrastructure.Repositories;

public class JsonNameGeneratorRepository : INpcGeneratorRepository
{
    private const string NpcGeneratorDataPath = "data/npcGenerator.json";

    public Task<NpcGeneratorData> GetAllGeneratorData()
    {
        throw new NotImplementedException();
    }

    public async Task<NpcNameOptions> GetAllNameOptions()
    {
        var jsonData = await ReadJsonFile();
        return jsonData == null ? throw new Exception("Json data not found") : jsonData.NameOptions;
    }

    public async Task<NpcMakeupOptions> GetAllMakeupOptions()
    {
        var jsonData = await ReadJsonFile();
        return jsonData == null ? throw new Exception("Json data not found") : jsonData.NpcMakeupOptions;
    }

    private async Task<NpcGeneratorData?> ReadJsonFile()
    {
        var path = GetJsonFilePath();
        try
        {
            var jsonString = await File.ReadAllTextAsync(path);
            var npcGeneratorData = JsonSerializer.Deserialize<NpcGeneratorData>(jsonString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return npcGeneratorData;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private string GetJsonFilePath()
    {
        return Path.Combine(Directory.GetCurrentDirectory(), NpcGeneratorDataPath);
    }
}