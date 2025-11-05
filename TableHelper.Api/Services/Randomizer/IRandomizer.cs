namespace TableHelper.Api.Services.Randomizer;

public interface IRandomizer<T> where T : class
{
    /// <summary>
    /// Returns a random subset of unique entries from the entries set
    /// </summary>
    /// <param name="entries">the set of data used to get the random data from</param>
    /// <param name="numberOfEntriesToReturn">the number of entries to return</param>
    /// <returns></returns>
    public IEnumerable<T> GetRandomEntries(List<T> entries, int numberOfEntriesToReturn);
}