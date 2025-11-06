using TableHelper.Infrastructure.Services;
using TableHelper.Models.Generators.Problem;

namespace TableHelper.Infrastructure.Repositories;

public class JsonProblemGeneratorRepository(JsonFileDeserializer<ProblemGeneratorData> deserializer) : IProblemGeneratorRepository
{
    private const string ProblemGeneratorDataPath = "data/SWN/problemGenerator.json";
    
    public async Task<ProblemGeneratorData> GetProblemGeneratorData()
    {
        var jsonData = await deserializer.ReadJsonFile(ProblemGeneratorDataPath);
        return jsonData ?? throw new Exception("JSON data not found");
    }
}