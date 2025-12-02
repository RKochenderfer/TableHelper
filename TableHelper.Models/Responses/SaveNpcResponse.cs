using TableHelper.Models.Npc;

namespace TableHelper.Models.Responses;

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
    /// The optional field that contains the saved NPC info
    /// </summary>
    public NpcInfo? NpcInfo { get; init; }

    /// <summary>
    /// The id of the created NPC
    /// </summary>
    public int? Id { get; init; }

    private SaveNpcResponse(bool ok, string? errorMessage, NpcInfo? npcInfo, int? id)
    {
        Ok = ok;
        ErrorMessage = errorMessage;
        NpcInfo = npcInfo;
        Id = id;
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
            npcInfo: null,
            id: null);
    }

    /// <summary>
    /// Creates a successful Save NPC Response
    /// </summary>
    /// <param name="npcInfo">The NPC info that was saved</param>
    /// <param name="id">The id for the newly saved NPC</param>
    /// <returns></returns>
    public static SaveNpcResponse Success(NpcInfo npcInfo, int id)
    {
        return new SaveNpcResponse(
            ok: true,
            errorMessage: null,
            npcInfo: npcInfo,
            id: id);
    }
}