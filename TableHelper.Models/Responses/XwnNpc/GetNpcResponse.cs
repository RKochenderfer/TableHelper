using TableHelper.Models.Npc;

namespace TableHelper.Models.Responses;

/// <summary>
/// The response for the results of an individual NPC
/// </summary>
public class GetNpcResponse(int? id, NpcInfo? npc, bool ok, string? errorMessage)
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
    /// The NPC information
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
    public static GetNpcResponse Success(int id, NpcInfo npc)
    {
        return new GetNpcResponse(id, npc, true, null);
    }

    /// <summary>
    /// Creates a failed get NPC response
    /// </summary>
    /// <param name="errorMessage">The error that occurred in the application</param>
    /// <returns></returns>
    public static GetNpcResponse Failure(string errorMessage)
    {
        return new GetNpcResponse(null, null, false, errorMessage);
    }

    /// <summary>
    /// Creates a failed get NPC response that indicates it was not found
    /// </summary>
    /// <param name="id">The id the request was looking for</param>
    /// <returns></returns>
    public static GetNpcResponse NotFound(int id)
    {
        return new  GetNpcResponse(id, null, false, $"NPC with id {id} was not found");
    }
}