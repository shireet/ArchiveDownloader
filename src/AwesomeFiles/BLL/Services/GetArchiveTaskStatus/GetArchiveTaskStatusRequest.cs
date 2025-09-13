using MediatR;

namespace AwesomeFiles.BLL.Services.GetArchiveTaskStatus;

public sealed record GetArchiveTaskStatusRequest : IRequest<GetArchiveTaskStatusResponse>
{
    public Guid Id { get; }

    public GetArchiveTaskStatusRequest(Guid id)
    {
        Id = id;
    }
}