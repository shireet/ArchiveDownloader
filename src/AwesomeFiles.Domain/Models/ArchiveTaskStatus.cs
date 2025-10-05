using AwesomeFiles.Domain.Models.Enum;

namespace AwesomeFiles.Domain.Models;

public class ArchiveTaskStatus
{
    public required Guid Id { get; init; }
    public required ArchiveStatus Status { get; init; }
    public string? TaskErrorMessage { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? CompletedAt { get; init; }
}