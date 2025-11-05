namespace TableHelper.Models.Requests;

public class ProblemGenerationRequest : IRequest
{
    public int NumberOfProblems { get; init; }

    public static ProblemGenerationRequest From(int numberOfProblems)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberOfProblems);

        return new ProblemGenerationRequest
        {
            NumberOfProblems = numberOfProblems
        };
    }

    public bool Validate()
    {
        return NumberOfProblems > 0;
    }
}