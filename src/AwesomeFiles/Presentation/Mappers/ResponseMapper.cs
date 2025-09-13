using AwesomeFiles.BLL.Exceptions;
using AwesomeFiles.BLL.Services.GetArchiveTaskStatus;
using AwesomeFiles.Presentation.Models.Dtos;
using AwesomeFiles.Presentation.Models.Enums;

namespace AwesomeFiles.Presentation.Mappers;

public static class ResponseMapper
{
    public static ArchiveTaskStatusResponse ToGetArchiveTaskStatusResponse(this GetArchiveTaskStatusResponse status)
    {
        return new ArchiveTaskStatusResponse
        (
            id: status.Id,
            status: status.Status.ToResponseArchiveStatusEnum(),
            errorMessage: status.TaskErrorMessage,
            createdAt: status.CreatedAt,
            completedAt: status.CompletedAt
        );
    }

    private static ArchiveStatus ToResponseArchiveStatusEnum(this AwesomeFiles.BLL.Models.Enum.ArchiveStatus status)
    {
        return status switch
        {
            BLL.Models.Enum.ArchiveStatus.Pending => ArchiveStatus.Pending,
            BLL.Models.Enum.ArchiveStatus.Processing => ArchiveStatus.Processing,
            BLL.Models.Enum.ArchiveStatus.Completed => ArchiveStatus.Completed,
            BLL.Models.Enum.ArchiveStatus.Failed => ArchiveStatus.Failed,
            _ => throw new InvalidTypeException(nameof(status))
        };
    }

    public static StartArchiveResponse ToStartArchiveResponse(this Guid id)
    {
        return new StartArchiveResponse(id);
    }

    public static GetAllFilesResponse ToGetAllFilesResponse(this List<string> fileNames)
    {
        return new GetAllFilesResponse([..fileNames]);
    }
}

