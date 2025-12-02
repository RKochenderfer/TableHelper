using Microsoft.AspNetCore.Mvc;
using TableHelper.Infrastructure.Services.Savers;
using TableHelper.Models.Npc;
using TableHelper.Models.Requests;
using TableHelper.Models.Responses;

namespace TableHelper.Api.Controllers.Xwn;

[Route("api/xwn/[controller]")]
[ApiController]
public class XwnNpc(ILogger<XwnNpc> logger, XwnNpcService xwnNpcService) : ControllerBase
{
    /// <summary>
    /// Saves an NPC
    /// </summary>
    /// <param name="request">The NPC that will be saved</param>
    /// <returns>A response indicating the success of saving the NPC</returns>
    [HttpPost]
    public async Task<SaveNpcResponse> Post(SaveNpcRequest request)
    {
        logger.LogDebug("Saving NPC");
        var saveResult = await SaveNpcAsync(request.Npc);
        logger.LogDebug("Completed Saving NPC");

        return saveResult;
    }

    /// <summary>
    /// Gets all saved NPCs
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<GetAllNpcResponse> GetAll()
    {
        logger.LogDebug("Retrieving All NPCs");
        var npcs = await GetAllNpcsAsync();
        logger.LogDebug("Completed retrieving All NPCs");

        return npcs;
    }

    /// <summary>
    /// Retrieves the NPC information for a specific NPC
    /// </summary>
    /// <param name="id">The id of the NPC who's information is requested</param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<GetNpcResponse> Get(int id)
    {
        logger.LogDebug("Retrieving NPC");
        var npc = await GetAsync(id);
        logger.LogDebug("Completed retrieving NPC");
        return npc;
    }

    private async Task<GetNpcResponse> GetAsync(int id)
    {
        try
        {
            var result = await xwnNpcService.GetAsync(id);
            return result == null ? GetNpcResponse.NotFound(id) : GetNpcResponse.Success(id, result.Npc);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching NPC");
            return GetNpcResponse.Failure(ex.Message);
        }
    }

    private async Task<GetAllNpcResponse> GetAllNpcsAsync()
    {
        try
        {
            var result = await xwnNpcService.GetAllAsync();
            return GetAllNpcResponse.Success(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching All NPCs");
            return GetAllNpcResponse.Failure(ex.Message);
        }
    }

    private async Task<SaveNpcResponse> SaveNpcAsync(NpcInfo npcInfo)
    {
        try
        {
            var result = await xwnNpcService.SaveAsync(npcInfo);
            return SaveNpcResponse.Success(npcInfo, result.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error saving NPC");
            return SaveNpcResponse.Failure(ex.Message);
        }
    }
}