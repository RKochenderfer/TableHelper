using System.Text.Json;
using Microsoft.Extensions.Logging;
using TableHelper.Models.Generators;
using TableHelper.Models.Generators.Npc;

namespace TableHelper.Infrastructure.Repositories;

public class JsonAdventureSeedGeneratorRepository(ILogger<JsonAdventureSeedGeneratorRepository> logger)
    : IAdventureSeedGeneratorRepository
{
    private const string AdventureSeedGeneratorDataPath = "data/adventureSeedGenerator.json";

    public async Task<AdventureSeedGeneratorData> GetAdventureSeeds()
    {
        var jsonData = await ReadJsonFile();
        return jsonData ?? throw new Exception("JSON data not found");
    }
    
    private async Task<AdventureSeedGeneratorData?> ReadJsonFile()
    {
        var path = GetJsonFilePath();
        try
        {
            var jsonString = await File.ReadAllTextAsync(path);
            var adventureSeedGeneratorData = JsonSerializer.Deserialize<AdventureSeedGeneratorData>(jsonString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return adventureSeedGeneratorData;
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error reading json file");
            throw;
        }
    }
    
    private string GetJsonFilePath()
    {
        return Path.Combine(Directory.GetCurrentDirectory(), AdventureSeedGeneratorDataPath);
    }
}