namespace AwesomeFiles.BLL.Services;

public class ResponseBase
{
    public bool Successful { get; init; }
    public Exception? Exception { get; init; }

    public ResponseBase()
    {
        Successful = true;
    }

    public ResponseBase(Exception exception)
    {
        Successful = false;
        Exception = exception;
    }
}