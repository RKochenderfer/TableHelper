using TableHelper.Models.Npc;

namespace TableHelper.Models.Responses.XwnNpc;

/// <summary>
/// Response for saving an NPC
/// </summary>
public class SaveNpcResponse
{
    /// <summary>
    /// Indicates true if the request was successful, false otherwise
    /// </summary>
    public bool Ok { get; init; }

    /// <summary>
    /// An optional field that contains any errors that occurred
    /// </summary>
    public string? ErrorMessage { get; init; }

    /// <summary>
    /// The saved NPC information
    /// </summary>
    public SavedNpc? SavedNpc { get; init; }
    
    /// <summary>
    /// Response for saving an NPC
    /// </summary>
    public SaveNpcResponse(bool ok, string? errorMessage, SavedNpc? savedNpc)
    {
        Ok = ok;
        ErrorMessage = errorMessage;
        SavedNpc = savedNpc;
    }

    /// <summary>
    /// Creates a failed Save NPC Response
    /// </summary>
    /// <param name="errorMessage">Error message that can be passed to the client indicating the error with the request</param>
    /// <returns></returns>
    public static SaveNpcResponse Failure(string errorMessage)
    {
        return new SaveNpcResponse(
            ok: false,
            errorMessage: errorMessage,
            savedNpc: null);
    }

    /// <summary>
    /// Creates a successful Save NPC Response
    /// </summary>
    /// <param name="npc">The NPC info that was saved</param>
    /// <returns></returns>
    public static SaveNpcResponse Success(SavedNpc npc)
    {
        ArgumentNullException.ThrowIfNull(npc);
        
        return new SaveNpcResponse(
            ok: true,
            errorMessage: null,
            savedNpc: npc);
    }
}