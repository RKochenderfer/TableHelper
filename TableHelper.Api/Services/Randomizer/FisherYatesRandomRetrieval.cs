namespace TableHelper.Api.Services.Randomizer;

internal class FisherYatesRandomRetrieval<T>(Random rng) : IRandomizer<T> where T : class
{
    public IEnumerable<T> GetRandomEntries(List<T> entries, int numberOfEntriesToReturn)
    {
        var shuffledEntries = FisherYatesShuffle(entries);

        return shuffledEntries.Take(numberOfEntriesToReturn);
    }

    private List<T> FisherYatesShuffle(List<T> entries)
    {
        var shuffled = new List<T>(entries);
        var n = entries.Count;
        while (n > 1) 
        {
            var k = rng.Next(n--);
            (entries[n], entries[k]) = (entries[k], entries[n]);
        }

        return shuffled;
    }
}