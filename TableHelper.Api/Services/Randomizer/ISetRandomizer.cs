namespace TableHelper.Api.Services.Randomizer;

/// <summary>
/// Randomly retrieve data from a large set
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISetRandomizer<T> where T : class
{
    /// <summary>
    /// Returns a random subset of unique entries from the entries set
    /// </summary>
    /// <param name="entries">the set of data used to get the random data from</param>
    /// <param name="numberOfEntriesToReturn">the number of entries to return</param>
    /// <returns></returns>
    public IEnumerable<T> GetRandomElementSet(T[] entries, int numberOfEntriesToReturn);
    
    /// <summary>
    /// Returns a single random element from the entries set
    /// </summary>
    /// <param name="entries"></param>
    /// <returns></returns>
    public T GetRandomElement(T[] entries);
}