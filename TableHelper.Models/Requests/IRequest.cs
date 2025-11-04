namespace TableHelper.Models.Requests;

/// <summary>
/// A request to the server
/// </summary>
public interface IRequest
{
    /// <summary>
    /// Checks if the request contents are valid. 
    /// </summary>
    public bool Validate();
}