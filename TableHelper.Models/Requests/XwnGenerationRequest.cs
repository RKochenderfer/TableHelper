namespace TableHelper.Models.Requests;

public class XwnGenerationRequest : IRequest
{
    /// <summary>
    /// The type of generation that is to be performed
    /// </summary>
    public XwnGenerationType Type { get; init; }
    /// <summary>
    /// Request to generate NPCs. Only required when the type is <see cref="XwnGenerationType.Npc"/>
    /// </summary>
    public NpcGenerationRequest? NpcGenerationRequest { get; init; }
    
    public AdventureSeedGenerateRequest? AdventureSeedGenerationRequest { get; init; }
    public PatronGenerationRequest? PatronGenerationRequest { get; init; }

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
    
    /// <summary>
    /// Create a new request to generate adventure seeds
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static XwnGenerationRequest From(AdventureSeedGenerateRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        return new XwnGenerationRequest
            { Type = XwnGenerationType.AdventureSeed, AdventureSeedGenerationRequest = request };
    }

    /// <summary>
    /// Creates a new request to generate patrons
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static XwnGenerationRequest From(PatronGenerationRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        return new XwnGenerationRequest
            { Type = XwnGenerationType.Patron, PatronGenerationRequest = request };
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