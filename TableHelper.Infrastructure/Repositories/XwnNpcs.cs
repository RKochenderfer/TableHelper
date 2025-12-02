using Microsoft.EntityFrameworkCore;
using TableHelper.Infrastructure.Database.Context;
using TableHelper.Infrastructure.Database.Models;

namespace TableHelper.Infrastructure.Repositories;

/// <summary>
/// The repository for XWN Npcs
/// </summary>
/// <param name="context"></param>
public class XwnNpcsRepository(TableHelperContext context)
{
    /// <summary>
    /// Adds a new NPC entry to the XwnNpc table
    /// </summary>
    /// <param name="npc">The NPC information to add</param>
    /// <returns></returns>
    public async Task<XwnNpc> AddAsync(XwnNpc npc)
    {
        var result = await context.XwnNpcs.AddAsync(npc);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Retrieves all NPCs in the repository
    /// </summary>
    /// <returns></returns>
    public async Task<List<XwnNpc>> GetAllAsync()
    {
        var result = await context.XwnNpcs.ToListAsync();
        return result;
    }

    /// <summary>
    /// Gets the NPC with the provided id if found
    /// </summary>
    /// <param name="id">The id of the NPC you are looking for</param>
    /// <returns><see cref="XwnNpc"/> if found, null otherwise</returns>
    public async Task<XwnNpc?> GetAsync(int id)
    {
        return await context.XwnNpcs.FindAsync(id);
    }
}