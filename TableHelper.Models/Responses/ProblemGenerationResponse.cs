using TableHelper.Models.Problem;

namespace TableHelper.Models.Responses;

public class ProblemGenerationResponse : GenerateResponse
{
    public IEnumerable<ProblemInfo> Problems { get; set; }

    public ProblemGenerationResponse(bool isSuccessful, string? errorMessage, IEnumerable<ProblemInfo> problems) : base(
        isSuccessful, errorMessage)
    {
        Problems = problems;
    }
    
    public static ProblemGenerationResponse Success(IEnumerable<ProblemInfo> problems)
    {
        ArgumentNullException.ThrowIfNull(problems);

        return new ProblemGenerationResponse(isSuccessful: true, errorMessage: null,
            problems: problems);
    }

    public static ProblemGenerationResponse Fail(string errorMessage)
    {
        return new ProblemGenerationResponse(isSuccessful: false, errorMessage: errorMessage,
            problems: new List<ProblemInfo>());
    }
}