using AwesomeFiles.Application.Services.GetArchiveTaskStatus;
using AwesomeFiles.Domain.Exceptions;
using AwesomeFiles.Domain.Models;
using AwesomeFiles.Domain.Models.Enum;
using AwesomeFiles.Infrastructure.Repositories.Entities;

namespace AwesomeFiles.Application.Extensions;

public static class ArchiveStatusMapper
{
    public static ArchiveTaskStatus ToBll(this ArchiveTaskStatusEntity statusEntity)
    {
        return new ArchiveTaskStatus
        {
            Id = statusEntity.Id,
            Status = statusEntity.Status.ToBllArchiveStatusEnum(),
            TaskErrorMessage = statusEntity.TaskErrorMessage,
            CreatedAt = statusEntity.CreatedAt,
            CompletedAt = statusEntity.CompletedAt
        };
    }

    public static GetArchiveTaskStatusResponse ToResponse(this ArchiveTaskStatus status)
    {
        return new GetArchiveTaskStatusResponse
        (
            status.Id,
            status.Status,
            status.TaskErrorMessage,
            status.CreatedAt,
            status.CompletedAt
        );
    }
    public static ArchiveStatus ToBllArchiveStatusEnum(this AwesomeFiles.Infrastructure.Repositories.Entities.Enums.ArchiveStatus status)
    {
        return status switch
        {
            Infrastructure.Repositories.Entities.Enums.ArchiveStatus.Pending => ArchiveStatus.Pending,
            Infrastructure.Repositories.Entities.Enums.ArchiveStatus.Processing => ArchiveStatus.Processing,
            Infrastructure.Repositories.Entities.Enums.ArchiveStatus.Completed => ArchiveStatus.Completed,
            Infrastructure.Repositories.Entities.Enums.ArchiveStatus.Failed => ArchiveStatus.Failed,
            _ => throw new InvalidTypeException(nameof(status))
        };
    }
    
    public static AwesomeFiles.Infrastructure.Repositories.Entities.Enums.ArchiveStatus ToDallArchiveStatusEnum(this ArchiveStatus status)
    {
        return status switch
        {
            ArchiveStatus.Pending => Infrastructure.Repositories.Entities.Enums.ArchiveStatus.Pending,
            ArchiveStatus.Processing => Infrastructure.Repositories.Entities.Enums.ArchiveStatus.Processing,
            ArchiveStatus.Completed => Infrastructure.Repositories.Entities.Enums.ArchiveStatus.Completed,
            ArchiveStatus.Failed => Infrastructure.Repositories.Entities.Enums.ArchiveStatus.Failed,
            _ => throw new InvalidTypeException(nameof(status))
        };
    }
    
    
}