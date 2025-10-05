using AwesomeFiles.Presentation.Models.Enums;

namespace AwesomeFiles.Presentation.Models.Dtos;

public class ArchiveTaskStatusResponse : ResponseBase
{
    public Guid? Id { get; init; }
    public ArchiveStatus? Status { get; init; }
    public string? TaskErrorMessage { get; init; }
    public DateTime? CreatedAt { get; init; }
    public DateTime? CompletedAt { get; init; }

    public ArchiveTaskStatusResponse(Guid id, ArchiveStatus status, string? errorMessage, DateTime createdAt,
        DateTime? completedAt)
    {
        Id = id;
        Status = status;
        ErrorMessage = errorMessage;
        CreatedAt = createdAt;
        CompletedAt = completedAt;
    }
    
    public ArchiveTaskStatusResponse(string? errorMessage) : base(errorMessage) { }
}