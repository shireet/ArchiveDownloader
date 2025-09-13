namespace ApiClient.Infrastructure.Models;

public class ResponseBase
{
    public bool Successful { get; init; }
    public string? ErrorMessage { get; init; }
}