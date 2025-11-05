namespace TableHelper.Models.Requests;

/// <summary>
/// Request to generate random patrons
/// </summary>
public class PatronGenerationRequest : IRequest
{
    public int PatronsToGenerate { get; init; }

    public static PatronGenerationRequest From(int patronsToGenerate)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(patronsToGenerate);
        
        return new PatronGenerationRequest { PatronsToGenerate = patronsToGenerate };
    }
    
    public bool Validate()
    {
        return PatronsToGenerate != 0;
    }
}