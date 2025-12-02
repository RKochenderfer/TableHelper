using TableHelper.Models.Npc;

namespace TableHelper.Models.Responses;

/// <summary>
/// Response for retrieving all saved NPCs
/// </summary>
/// <param name="npcs"></param>
public class GetAllNpcResponse(bool ok, List<SavedNpc>? npcs, string? errorMessage)
{
    /// <summary>
    /// The saved NPCs
    /// </summary>
    public List<SavedNpc>? Npcs { get; init; } = npcs;

    /// <summary>
    /// Indicates if the response was successful or not
    /// </summary>
    public bool Ok { get; init; } = ok;
    
    public string? ErrorMessage { get; init; } = errorMessage;
    

    /// <summary>
    /// Creates a new response for getting all NPCs
    /// </summary>
    /// <param name="npcs"></param>
    /// <returns></returns>
    public static GetAllNpcResponse Success(List<SavedNpc> npcs)
    {
        ArgumentNullException.ThrowIfNull(npcs);
        
        return new GetAllNpcResponse(true, npcs, null);
    }

    public static GetAllNpcResponse Failure(string? errorMessage)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(errorMessage);
        
        return new GetAllNpcResponse(false, null, errorMessage);
    }
}