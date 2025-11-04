using TableHelper.Models.Generators.Npc;
using TableHelper.Models.Npc;
using TableHelper.Models.Requests;

namespace TableHelper.Infrastructure.Repositories;

/// <summary>
/// Repository for the data used to generate NPCs
/// </summary>
public interface INpcGeneratorRepository
{
    /// <summary>
    /// Retrieve all the generator data
    /// </summary>
    /// <returns></returns>
    public Task<NpcGeneratorData> GetAllGeneratorData();
    
    /// <summary>
    /// Retrieve all the name option generation data
    /// </summary>
    /// <returns></returns>
    public Task<NpcNameOptions> GetAllNameOptions();
    
    /// <summary>
    /// Retrieve all the NPC Make Options
    /// </summary>
    /// <returns></returns>
    public Task<NpcMakeupOptions> GetAllMakeupOptions();
}