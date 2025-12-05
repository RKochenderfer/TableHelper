using System.Net.Http.Json;
using TableHelper.Models.Npc;
using TableHelper.Models.Requests.XwnNpc;
using TableHelper.Models.Responses.XwnNpc;

namespace TableHelper.Services;

public class XwnNpcApiService(HttpClient httpClient)
{
    /// <summary>
    /// Deletes an NPC from the server
    /// </summary>
    /// <param name="npcId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteXwnNpc(int npcId)
    {
        try
        {
            var response = await httpClient.DeleteAsync($"{Constants.Urls.XwnNpcUrl}/{npcId}");
            var content = await response.Content.ReadFromJsonAsync<DeleteNpcResponse>();
            
            return content is { Ok: true };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
    /// <summary>
    /// Saves the NPC on the server
    /// </summary>
    /// <param name="npcInfo"></param>
    /// <returns></returns>
    public async Task<SavedNpc?> SaveXwnNpc(NpcInfo npcInfo)
    {
        try
        {
            var saveNpcRequest = SaveNpcRequest.From(npcInfo);
            var response = await httpClient.PostAsJsonAsync(Constants.Urls.XwnNpcUrl, saveNpcRequest);;
            var content = await response.Content.ReadFromJsonAsync<SaveNpcResponse>();
            
            return content?.SavedNpc;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}