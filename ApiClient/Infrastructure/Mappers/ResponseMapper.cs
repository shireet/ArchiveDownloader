using ApiClient.BLL.Models;
using ApiClient.Infrastructure.Models.Dtos;
using ApiClient.BLL.Models.Enum;

namespace ApiClient.Infrastructure.Mappers;

public static class ResponseMapper
{
    public static ArchiveTaskStatus ToBll(this ArchiveTaskStatusResponse archiveTaskStatusResponse)
    {
        return new ArchiveTaskStatus
        {
            Id = archiveTaskStatusResponse.Id,
            Status = (ArchiveStatus?)archiveTaskStatusResponse.Status,
            TaskErrorMessage = archiveTaskStatusResponse.TaskErrorMessage,
            CreatedAt = archiveTaskStatusResponse.CreatedAt,
            CompletedAt = archiveTaskStatusResponse.CompletedAt
        };
    }

    private static ArchiveStatus ToBllEnum(this Infrastructure.Models.Enums.ArchiveStatus? archiveStatus)
    {
        return archiveStatus switch
        {
            Models.Enums.ArchiveStatus.Pending => ArchiveStatus.Pending,
            Models.Enums.ArchiveStatus.Processing => ArchiveStatus.Processing,
            Models.Enums.ArchiveStatus.Completed => ArchiveStatus.Completed,
            Models.Enums.ArchiveStatus.Failed => ArchiveStatus.Failed,
            _ => throw new ArgumentOutOfRangeException(nameof(archiveStatus), archiveStatus, null)
        };
    }
}