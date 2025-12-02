
using TableHelper.Infrastructure.Database.Models;
using TableHelper.Infrastructure.Repositories;
using TableHelper.Models.Npc;

namespace TableHelper.Infrastructure.Services.Savers;

/// <summary>
/// Performs actions for XWN NPCs
/// </summary>
/// <param name="repo"></param>
public class XwnNpcService(XwnNpcsRepository repo)
{
    /// <summary>
    /// Saves an XWN NPC
    /// </summary>
    /// <param name="npc">The NPC to be saved</param>
    /// <returns>The saved NPC Data</returns>
    public async Task<XwnNpc> SaveAsync(NpcInfo npc)
    {
        var xwnNpc = npc.ToDbModel();
        return await repo.AddAsync(xwnNpc);
    }
}