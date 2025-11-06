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

    /// <summary>
    /// Request to generate adventure seeds. Only required when the type is <see cref="XwnGenerationType.AdventureSeed"/>
    /// </summary>
    public AdventureSeedGenerateRequest? AdventureSeedGenerationRequest { get; init; }

    /// <summary>
    /// Request to generate patrons. Only required when the type is <see cref="XwnGenerationType.Patron"/>
    /// </summary>
    public PatronGenerationRequest? PatronGenerationRequest { get; init; }

    /// <summary>
    /// Request to generate problems. Only required when the type is <see cref="XwnGenerationType.Problem"/>
    /// </summary>
    public ProblemGenerationRequest? ProblemGenerationRequest { get; init; }
    
    /// <summary>
    /// Request to generate urban encounters. Only required when the type is <see cref="XwnGenerationType.UrbanEncounter"/>
    /// </summary>
    public UrbanEncounterRequest? UrbanEncounterGenerationRequest { get; init; }

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

    /// <summary>
    /// Creates a new request to generate problems
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static XwnGenerationRequest From(ProblemGenerationRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        return new XwnGenerationRequest
            { Type = XwnGenerationType.Problem, ProblemGenerationRequest = request };
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