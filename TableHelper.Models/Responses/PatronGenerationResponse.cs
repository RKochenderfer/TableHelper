namespace TableHelper.Models.Responses;

public class PatronGenerationResponse : GenerateResponse
{
    public IEnumerable<Patron> Patrons { get; init; }

    public PatronGenerationResponse(bool isSuccessful, string? errorMessage, IEnumerable<Patron> patrons) : base(isSuccessful, errorMessage)
    {
        Patrons = patrons;
    }
    
    public static PatronGenerationResponse Success(IEnumerable<Patron> patrons)
    {
        return new PatronGenerationResponse(isSuccessful: true, errorMessage: null, patrons: patrons);
    }

    public new static PatronGenerationResponse Failure(string errorMessage)
    {
        return new PatronGenerationResponse(isSuccessful: false, errorMessage: errorMessage, patrons: new List<Patron>());
    }
}