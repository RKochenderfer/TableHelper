namespace TableHelper.Api.Services.Randomizer;

internal class FisherYatesRandomRetrieval<T>(Random rng) : ISetRandomizer<T> where T : class
{
    public IEnumerable<T> GetRandomElementSet(T[] entries, int numberOfEntriesToReturn)
    {
        ArgumentNullException.ThrowIfNull(entries);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberOfEntriesToReturn);

        var shuffledEntries = FisherYatesShuffle(entries);

        return shuffledEntries.Take(numberOfEntriesToReturn);
    }

    public T GetRandomElement(T[] entries)
    {
        ArgumentNullException.ThrowIfNull(entries);
        var randomIndex = rng.Next(0, entries.Length);
        return entries[randomIndex];
    }

    private T[] FisherYatesShuffle(T[] entries)
    {
        var n = entries.Length;
        while (n > 1)
        {
            var k = rng.Next(n--);
            (entries[n], entries[k]) = (entries[k], entries[n]);
        }

        return entries;
    }
}