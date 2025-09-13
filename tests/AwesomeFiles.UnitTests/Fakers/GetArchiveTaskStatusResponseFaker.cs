using AutoBogus;
using AwesomeFiles.BLL.Services.GetArchiveTaskStatus;

namespace AwesomeFiles.UnitTests.Fakers;

public static class GetArchiveTaskStatusResponseFaker
{
    public static GetArchiveTaskStatusResponse Generate()
    {
        var t = 
        new AutoFaker<GetArchiveTaskStatusResponse>()
            .RuleFor(x => x.Exception, _ => null)
            .Generate();
        return t;
    }
    public static GetArchiveTaskStatusResponse WithId(this GetArchiveTaskStatusResponse response, Guid id)
    {
        return new GetArchiveTaskStatusResponse
        (
            id,
            response.Status,
            response.TaskErrorMessage,
            response.CreatedAt,
            response.CompletedAt
            );
    }
}