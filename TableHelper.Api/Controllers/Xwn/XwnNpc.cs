using Microsoft.AspNetCore.Mvc;
using TableHelper.Infrastructure.Repositories;
using TableHelper.Infrastructure.Services.Savers;
using TableHelper.Models.Npc;
using TableHelper.Models.Requests.XwnNpc;
using TableHelper.Models.Responses;
using TableHelper.Models.Responses.XwnNpc;

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
        logger.LogInformation("Retrieving All NPCs");
        var npcs = await GetAllNpcsAsync();
        logger.LogInformation("Completed retrieving All NPCs");

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
        var result = await DeleteNpcAsync(id);
        logger.LogDebug("Retrieving NPC");
        return result;
    }

    /// <summary>
    /// Updates the details of a saved NPC
    /// </summary>
    /// <param name="id">The id of the NPC being updated</param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public async Task<UpdateNpcResponse> Put(int id, [FromBody] UpdateNpcRequest request)
    {
        logger.LogDebug("Updating NPC");
        var result = await UpdateNpcAsync(id, request);
        logger.LogDebug("Completed updating NPC");
        return result;
    }

    private async Task<UpdateNpcResponse> UpdateNpcAsync(int id, UpdateNpcRequest request)
    {
        try
        {
            var result = await xwnNpcService.UpdateNpcAsync(id, request);
            if (result == null)
            {
                return UpdateNpcResponse.NotFound(id);
            }
            var npcInfo = result.ToNpcInfo();
            return UpdateNpcResponse.Success(id, npcInfo);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching NPC");
            return UpdateNpcResponse.Failure(id, ex.Message);
        }
    }

    private async Task<DeleteNpcResponse> DeleteNpcAsync(int id)
    {
        try
        {
            var isDeleted = await xwnNpcService.DeleteAsync(id);
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
            var savedNpc = SavedNpc.From(result.Id, result.ToNpcInfo());
            return SaveNpcResponse.Success(savedNpc);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error saving NPC");
            return SaveNpcResponse.Failure(ex.Message);
        }
    }
}