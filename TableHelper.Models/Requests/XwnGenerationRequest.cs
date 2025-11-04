namespace TableHelper.Models.Requests;

public class XwnGenerationRequest : IRequest
{
    public XwnGenerationType Type { get; init; }
    public NpcGenerationRequest? NpcGenerationRequest { get; init; }

    /// <summary>
    /// Create a new request to generate NPCs
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static XwnGenerationRequest From(NpcGenerationRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        return new XwnGenerationRequest
            { Type = XwnGenerationType.Npc, NpcGenerationRequest = request };
    }

    public bool Validate()
    {
        return Type switch
        {
            XwnGenerationType.Npc => ValidateNpcGenerationRequest(NpcGenerationRequest),
            _ => false
        };
    }

    private bool ValidateNpcGenerationRequest(NpcGenerationRequest? request)
    {
        return request is not null && request.Validate();
    }
}

public enum XwnGenerationType
{
    AdventureSeed = 0,
    Npc = 1,
    Patron = 2,
    Place = 3,
    Problem = 4,
    UrbanEncounter = 5,
}