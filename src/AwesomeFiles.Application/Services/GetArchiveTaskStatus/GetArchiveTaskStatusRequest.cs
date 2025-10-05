using MediatR;

namespace AwesomeFiles.Application.Services.GetArchiveTaskStatus;

public sealed record GetArchiveTaskStatusRequest : IRequest<GetArchiveTaskStatusResponse>
{
    public Guid Id { get; }

    public GetArchiveTaskStatusRequest(Guid id)
    {
        Id = id;
    }
}