namespace TableHelper.Models.Responses;

public class GenerateResponse(bool isSuccessful, string? errorMessage)
{
    public bool IsSuccessful { get; } = isSuccessful;
    public string? ErrorMessage { get; } = errorMessage;

    public static GenerateResponse Failure(string errorMessage)
    {
        return new GenerateResponse(false, errorMessage);
    }
}