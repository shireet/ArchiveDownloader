namespace AwesomeFiles.Presentation.Models;

public class ResponseBase
{
    public bool Successful { get; init; }
    public string? ErrorMessage { get; init; }

    public ResponseBase()
    {
        Successful = true;
    }

    public ResponseBase(string? errorMessage)
    {
        Successful = false;
        ErrorMessage = errorMessage;
    }
}