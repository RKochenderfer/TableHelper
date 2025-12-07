namespace TableHelper.Models;

public class ShowToastRequest
{
    public readonly bool IsSuccessful;
    public readonly string Message;
    
    private ShowToastRequest(bool isSuccessful, string message)
    {
        IsSuccessful = isSuccessful;
        Message = message;
    }

    public static ShowToastRequest Success(string message)
    {
        return new ShowToastRequest(true,  message);
    }

    public static ShowToastRequest Failure(string message)
    {
        return new ShowToastRequest(false,  message);
    }
}