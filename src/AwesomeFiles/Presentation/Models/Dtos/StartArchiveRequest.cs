namespace AwesomeFiles.Presentation.Models.Dtos;

public record StartArchiveRequest
{
    public List<string> FileNames { get; init; } = [];
}