namespace TableHelper.Models.Npc;

/// <summary>
/// A saved NPC entry
/// </summary>
/// <param name="id">The NPC's id</param>
/// <param name="npc">The NPC information</param>
public class SavedNpc(int id, NpcInfo npc)
{
    /// <summary>
    /// The NPC Id
    /// </summary>
    public int Id { get; init; } = id;
    
    /// <summary>
    /// The NPC information
    /// </summary>
    public NpcInfo Npc { get; init; } = npc;

    /// <summary>
    /// Creates a new SavedNpc from the provided values
    /// </summary>
    /// <param name="id">The id of the NPC</param>
    /// <param name="npc">The NPC information</param>
    /// <returns></returns>
    public static SavedNpc From(int id, NpcInfo npc)
    {
        return new SavedNpc(id, npc);
    }
}