using TableHelper.Models.Npc;

namespace TableHelper.Models.Requests;

/// <summary>
/// A request to save an NPC on the server
/// </summary>
public class SaveNpcRequest(NpcInfo npc)
{
    /// <summary>
    /// The NPC to be saved
    /// </summary>
    public NpcInfo Npc { get; init; } = npc;

    /// <summary>
    /// Creates a new SaveNpcRequest to save the provided NPC
    /// </summary>
    /// <param name="npc"></param>
    /// <returns></returns>
    public static SaveNpcRequest From(NpcInfo npc)
    {
        ArgumentNullException.ThrowIfNull(npc);

        return new SaveNpcRequest(npc);
    }
}