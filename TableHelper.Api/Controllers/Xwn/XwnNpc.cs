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
    public async Task<SaveNpcResponse> Npc(SaveNpcRequest request)
    {
        logger.LogDebug("Saving NPC");
        var saveResult = await SaveNpc(request.Npc);
        logger.LogDebug("Completed Saving NPC");
        
        return saveResult;
    }

    private async Task<SaveNpcResponse> SaveNpc(NpcInfo npcInfo)
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