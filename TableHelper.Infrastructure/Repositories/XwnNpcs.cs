using Microsoft.EntityFrameworkCore;
using TableHelper.Infrastructure.Database.Context;
using TableHelper.Infrastructure.Database.Models;
using TableHelper.Models.Npc;

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

    /// <summary>
    /// Deletes the NPC with the provided id
    /// </summary>
    /// <param name="id">The id of the NPC you are deleting</param>
    /// <returns></returns>
    public async Task<int> DeleteAsync(int id)
    {
        var result = await context.XwnNpcs.Where(n => n.Id == id).ExecuteDeleteAsync();
        return result;
    }

    /// <summary>
    /// Updates an NPC's database entry
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updatedNpc"></param>
    /// <returns></returns>
    public async Task<XwnNpc?> UpdateNpcAsync(int id, XwnNpc updatedNpc)
    {
        var result = await context.XwnNpcs
            .Where(n => n.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(x => x.FirstName, updatedNpc.FirstName)
                .SetProperty(x => x.Surname, updatedNpc.Surname)
                .SetProperty(x => x.Gender, updatedNpc.Gender)
                .SetProperty(x => x.InitialManner, updatedNpc.InitialManner)
                .SetProperty(x => x.DefaultDealOutcome, updatedNpc.DefaultDealOutcome)
                .SetProperty(x => x.TheirMotivation, updatedNpc.TheirMotivation)
                .SetProperty(x => x.TheirWant, updatedNpc.TheirWant)
                .SetProperty(x => x.TheirPower, updatedNpc.TheirPower)
                .SetProperty(x => x.TheirBackground, updatedNpc.TheirBackground)
                .SetProperty(x => x.TheirRoleInSociety, updatedNpc.TheirRoleInSociety)
                .SetProperty(x => x.TheirBiggestProblem, updatedNpc.TheirBiggestProblem)
                .SetProperty(x => x.AgeDescription, updatedNpc.AgeDescription)
                .SetProperty(x => x.TheirGreatestDesire, updatedNpc.TheirGreatestDesire)
                .SetProperty(x => x.MostObviousCharacterTrait, updatedNpc.MostObviousCharacterTrait)
            );

        return result == 0 ? null : updatedNpc;
    }
}