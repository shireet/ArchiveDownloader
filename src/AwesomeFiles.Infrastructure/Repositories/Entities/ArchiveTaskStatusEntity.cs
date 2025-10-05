using AwesomeFiles.Infrastructure.Repositories.Entities.Enums;

namespace AwesomeFiles.Infrastructure.Repositories.Entities;

public record ArchiveTaskStatusEntity
{
    public required Guid Id { get; init; }
    public required ArchiveStatus Status { get; init; }
    public string? TaskErrorMessage { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? CompletedAt { get; init; }
}