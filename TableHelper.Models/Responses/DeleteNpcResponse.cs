namespace TableHelper.Models.Responses;

/// <summary>
/// Response from the API for a delete NPC request
/// </summary>
/// <param name="ok"></param>
/// <param name="npcId"></param>
/// <param name="errorMessage"></param>
public class DeleteNpcResponse(bool ok, int npcId, string? errorMessage)
{
    /// <summary>
    /// The status of the request
    /// </summary>
    public bool Ok { get; set; } = ok;
    
    /// <summary>
    /// The Id of the NPC that was deleted
    /// </summary>
    public int NpcId { get; set; } = npcId;
    
    /// <summary>
    /// A message about an error that occurred. Only set if Ok is false
    /// </summary>
    public string? ErrorMessage { get; set; } = errorMessage;
    
    public static DeleteNpcResponse Success(int npcId) => new DeleteNpcResponse(true, npcId, null);

    /// <summary>
    /// Creates a response message indicating that the delete npc request failed
    /// </summary>
    /// <param name="npcId">The id that was attempted to be dleted</param>
    /// <param name="errorMessage">The error that occurred</param>
    /// <returns></returns>
    public static DeleteNpcResponse Failed(int npcId, string errorMessage)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(errorMessage);
        
        return new DeleteNpcResponse(false, npcId, errorMessage);
    }
    
    /// <summary>
    /// Creates a response message indicating that NPC that was to be deleted was not found
    /// </summary>
    /// <param name="npcId">The id that was attempted to be dleted</param>
    /// <param name="errorMessage">The error that occurred</param>
    /// <returns></returns>
    public static DeleteNpcResponse NotFound(int npcId)
    {
        return new DeleteNpcResponse(false, npcId,$"NPC id {npcId} was not found");
    }
}