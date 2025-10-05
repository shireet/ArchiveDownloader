using MediatR;

namespace AwesomeFiles.Application.Services.GetArchive;

public sealed record GetArchiveRequest :  IRequest<GetArchiveResponse>
{
    public Guid Id { get; }

    public GetArchiveRequest(Guid id)
    {
        Id = id;
    }
}