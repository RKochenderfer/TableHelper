using TableHelper.Models.Npc;

namespace TableHelper.Models.Requests.XwnNpc;

public class UpdateNpcRequest(NpcInfo npc)
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
    public static UpdateNpcRequest From(NpcInfo npc)
    {
        ArgumentNullException.ThrowIfNull(npc);

        return new UpdateNpcRequest(npc);
    }
}