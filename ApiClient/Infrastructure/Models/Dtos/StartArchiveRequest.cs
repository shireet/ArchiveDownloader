namespace ApiClient.Infrastructure.Models.Dtos;

public class StartArchiveRequest
{
    public required List<string> FileNames { get; init; } = [];
}