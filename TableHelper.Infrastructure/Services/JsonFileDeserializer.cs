using System.Text.Json;

namespace TableHelper.Infrastructure.Services;

public class JsonFileDeserializer<T>
{
    public async Task<T?> ReadJsonFile(string relativePath)
    {
        var path = GetJsonFilePath(relativePath);
        try
        {
            var jsonString = await File.ReadAllTextAsync(path);
            var data = JsonSerializer.Deserialize<T>(jsonString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static string GetJsonFilePath(string path)
    {
        return Path.Combine(Directory.GetCurrentDirectory(), path);
    }
}