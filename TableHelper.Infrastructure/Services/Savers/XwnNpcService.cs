
using TableHelper.Infrastructure.Database.Models;
using TableHelper.Infrastructure.Repositories;
using TableHelper.Models.Npc;
using TableHelper.Models.Responses;

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

    /// <summary>
    /// Retrieves all saved XWN Npcs
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<SavedNpc>> GetAllAsync()
    {
        var npcs = await repo.GetAllAsync();
        var savedNpcs = npcs.Select(x => SavedNpc.From(x.Id, x.ToNpcInfo())).ToList();
        
        return savedNpcs;
    }

    /// <summary>
    /// Gets a specific NPC's information
    /// </summary>
    /// <param name="id">The id of the NPC you are looking for</param>
    /// <returns>The <see cref="SavedNpc" /> if an NPC with the provided <c>id</c> was found, false otherwise</returns>
    public async Task<SavedNpc?> GetAsync(int id)
    {
        var npc = await repo.GetAsync(id);
        if (npc == null)
        {
            return null;
        }
        var savedNpc = npc.ToNpcInfo();

        return SavedNpc.From(id, savedNpc);
    }

    /// <summary>
    /// Deletes an NPC with a provided id
    /// </summary>
    /// <param name="id">the id of the NPC being deleted</param>
    /// <returns>true if the entry was deleted, false otherwise</returns>
    public async Task<bool> Delete(int id)
    {
        var deletedCount = await repo.Delete(id);
        return deletedCount == 1;
    }
}