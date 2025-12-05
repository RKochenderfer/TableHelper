using TableHelper.Models.Npc;

namespace TableHelper.Models.Responses.XwnNpc;

/// <summary>
/// Response for updating an NPC
/// </summary>
/// <param name="id"></param>
/// <param name="npc"></param>
/// <param name="ok"></param>
/// <param name="errorMessage"></param>
public class UpdateNpcResponse(int? id, NpcInfo? npc, bool ok, string? errorMessage)
{
    /// <summary>
    /// Indicates if the request was successful or not
    /// </summary>
    public bool Ok { get; init; } = ok;
    
    /// <summary>
    /// The NPC Id
    /// </summary>
    public int? Id { get; init; } = id;
    
    /// <summary>
    /// The updated NPC information
    /// </summary>
    public NpcInfo? Npc { get; init; } = npc;
    
    /// <summary>
    /// Error that occurred while processing the request. Only set if Ok is false.
    /// </summary>
    public string? ErrorMessage { get; init; } = errorMessage;
    
    /// <summary>
    /// Creates a successful get NPC response
    /// </summary>
    /// <param name="id">the NPC's id</param>
    /// <param name="npc">The saved NPC's information</param>
    /// <returns></returns>
    public static UpdateNpcResponse Success(int id, NpcInfo npc)
    {
        return new UpdateNpcResponse(id, npc, true, null);
    }

    /// <summary>
    /// Creates a failed get NPC response
    /// </summary>
    /// <param name="id">The id of the NPC that was attempted to be updated</param>
    /// <param name="errorMessage">The error that occurred in the application</param>
    /// <returns></returns>
    public static UpdateNpcResponse Failure(int id, string errorMessage)
    {
        return new UpdateNpcResponse(id, null, false, errorMessage);
    }

    /// <summary>
    /// Creates a failed get NPC response that indicates it was not found
    /// </summary>
    /// <param name="id">The id the request was looking for</param>
    /// <returns></returns>
    public static UpdateNpcResponse NotFound(int id)
    {
        return new  UpdateNpcResponse(id, null, false, $"NPC with id {id} was not found");
    }
}