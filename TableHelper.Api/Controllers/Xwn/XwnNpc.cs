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
    /// <param name="id">The id of the NPC whose information is requested</param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<GetNpcResponse> Get(int id)
    {
        logger.LogDebug("Retrieving NPC");
        var npc = await GetAsync(id);
        logger.LogDebug("Completed retrieving NPC");
        return npc;
    }

    /// <summary>
    /// Deletes a saved NPC's details
    /// </summary>
    /// <param name="id">The id of the NPC being deleted</param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<DeleteNpcResponse> Delete(int id)
    {
        logger.LogDebug("Deleting NPC");
        var result = await DeleteNpc(id);
        logger.LogDebug("Retrieving NPC");
        return result;
    }

    private async Task<DeleteNpcResponse> DeleteNpc(int id)
    {
        try
        {
            var isDeleted = await xwnNpcService.Delete(id);
            return isDeleted ? DeleteNpcResponse.Success(id) : DeleteNpcResponse.NotFound(id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching NPC");
            return DeleteNpcResponse.Failed(id, ex.Message);
        }
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
            if (result.Count == 0)
            {
                return  GetAllNpcResponse.NotFound();
            }
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