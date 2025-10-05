using AwesomeFiles.Application.Services.GetArchiveTaskStatus;
using AwesomeFiles.Domain.Exceptions;
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

    private static ArchiveStatus ToResponseArchiveStatusEnum(this AwesomeFiles.Domain.Models.Enum.ArchiveStatus status)
    {
        return status switch
        {
            Domain.Models.Enum.ArchiveStatus.Pending => ArchiveStatus.Pending,
            Domain.Models.Enum.ArchiveStatus.Processing => ArchiveStatus.Processing,
            Domain.Models.Enum.ArchiveStatus.Completed => ArchiveStatus.Completed,
            Domain.Models.Enum.ArchiveStatus.Failed => ArchiveStatus.Failed,
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

