using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Configuration;
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
    /// Gets all of the saved NPCs
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<GetAllNpcResponse> GetAll()
    {
        logger.LogDebug("Retrieving All NPCs");
        var npcs = await GetAllNpcs();
        logger.LogDebug("Completed retrieving All NPCs");
        
        return npcs;
    }

    private async Task<GetAllNpcResponse> GetAllNpcs()
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