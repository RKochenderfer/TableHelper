using TableHelper.Infrastructure.Services;
using TableHelper.Models.Generators;

namespace TableHelper.Infrastructure.Repositories;

public class JsonPatronGeneratorRepository(JsonFileDeserializer<PatronGeneratorData> deserializer) : IPatronGeneratorRepository
{
    private const string PatronGeneratorDataPath = "data/patronGenerator.json";
    
    public async Task<PatronGeneratorData> GetAllPatronData()
    {
        var jsonData = await deserializer.ReadJsonFile(PatronGeneratorDataPath);
        return jsonData ?? throw new Exception("JSON data not found");
    }
    
    
}