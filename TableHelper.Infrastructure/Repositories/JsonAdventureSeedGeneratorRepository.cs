using System.Text.Json;
using Microsoft.Extensions.Logging;
using TableHelper.Infrastructure.Services;
using TableHelper.Models.Generators;
using TableHelper.Models.Generators.Npc;

namespace TableHelper.Infrastructure.Repositories;

public class JsonAdventureSeedGeneratorRepository(JsonFileDeserializer<AdventureSeedGeneratorData> deserializer)
    : IAdventureSeedGeneratorRepository
{
    private const string AdventureSeedGeneratorDataPath = "data/adventureSeedGenerator.json";

    public async Task<AdventureSeedGeneratorData> GetAdventureSeeds()
    {
        var jsonData = await deserializer.ReadJsonFile(AdventureSeedGeneratorDataPath);
        return jsonData ?? throw new Exception("JSON data not found");
    }
}