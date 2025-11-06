namespace TableHelper.Api.Services.Randomizer;

public class Randomizer(Random rnd)
{
    public string GetRandomElementFrom(string[] data)
    {
        var index = rnd.Next(0, data.Length);
        return data[index];
    }
}