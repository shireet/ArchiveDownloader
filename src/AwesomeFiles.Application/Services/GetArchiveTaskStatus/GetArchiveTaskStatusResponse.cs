using AwesomeFiles.Domain.Models.Enum;

namespace AwesomeFiles.Application.Services.GetArchiveTaskStatus;

public sealed class GetArchiveTaskStatusResponse : ResponseBase
{
    public Guid Id { get; }
    public ArchiveStatus Status { get;  }
    public string? TaskErrorMessage { get;  }
    public DateTime CreatedAt { get;  }
    public DateTime? CompletedAt { get; }

    public GetArchiveTaskStatusResponse(Guid id, ArchiveStatus status, string? errorMessage, DateTime createdAt,
        DateTime? completedAt)
    {
        Id = id;
        Status = status;
        TaskErrorMessage = errorMessage;
        CreatedAt = createdAt;
        CompletedAt = completedAt;
    }
    public GetArchiveTaskStatusResponse(Exception exception) : base(exception) { }
}