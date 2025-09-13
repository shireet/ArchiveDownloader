using ApiClient.Infrastructure.Models.Enums;

namespace ApiClient.Infrastructure.Models.Dtos;

public class ArchiveTaskStatusResponse : ResponseBase
{
    public Guid? Id { get; init; }
    public ArchiveStatus? Status { get; init; }
    public string? TaskErrorMessage { get; init; }
    public DateTime? CreatedAt { get; init; }
    public DateTime? CompletedAt { get; init; }

}