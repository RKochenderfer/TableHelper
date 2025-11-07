namespace TableHelper.Models.Requests;

/// <summary>
/// The type of data that requested to be generated
/// </summary>
public enum XwnGenerationType
{
    /// <summary>
    /// Generate adventure seeds
    /// </summary>
    AdventureSeed = 0,

    /// <summary>
    /// Generate npcs
    /// </summary>
    Npc = 1,

    /// <summary>
    /// Generate patrons
    /// </summary>
    Patron = 2,

    /// <summary>
    /// Generates a place
    /// </summary>
    Place = 3,

    /// <summary>
    /// Generates problems
    /// </summary>
    Problem = 4,

    /// <summary>
    /// Generates urban encounters
    /// </summary>
    UrbanEncounter = 5,

    /// <summary>
    /// Generates wilderness encounters
    /// </summary>
    WildernessEncounter = 6,
}