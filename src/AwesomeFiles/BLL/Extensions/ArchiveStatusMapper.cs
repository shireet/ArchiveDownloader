using AwesomeFiles.BLL.Exceptions;
using AwesomeFiles.DAL.Entities;
using AwesomeFiles.BLL.Models;
using AwesomeFiles.BLL.Models.Enum;
using AwesomeFiles.BLL.Services.GetArchiveTaskStatus;


namespace AwesomeFiles.BLL.Extensions;

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

    public static ArchiveStatus ToBllArchiveStatusEnum(this AwesomeFiles.DAL.Entities.Enums.ArchiveStatus status)
    {
        return status switch
        {
            DAL.Entities.Enums.ArchiveStatus.Pending => ArchiveStatus.Pending,
            DAL.Entities.Enums.ArchiveStatus.Processing => ArchiveStatus.Processing,
            DAL.Entities.Enums.ArchiveStatus.Completed => ArchiveStatus.Completed,
            DAL.Entities.Enums.ArchiveStatus.Failed => ArchiveStatus.Failed,
            _ => throw new InvalidTypeException(nameof(status))
        };
    }
    
    public static AwesomeFiles.DAL.Entities.Enums.ArchiveStatus ToDallArchiveStatusEnum(this ArchiveStatus status)
    {
        return status switch
        {
            ArchiveStatus.Pending => AwesomeFiles.DAL.Entities.Enums.ArchiveStatus.Pending,
            ArchiveStatus.Processing => AwesomeFiles.DAL.Entities.Enums.ArchiveStatus.Processing,
            ArchiveStatus.Completed => AwesomeFiles.DAL.Entities.Enums.ArchiveStatus.Completed,
            ArchiveStatus.Failed => AwesomeFiles.DAL.Entities.Enums.ArchiveStatus.Failed,
            _ => throw new InvalidTypeException(nameof(status))
        };
    }
    
    
}