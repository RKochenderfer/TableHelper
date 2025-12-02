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

    public static SavedNpc From(int id, NpcInfo npc)
    {
        return new SavedNpc(id, npc);
    }
}