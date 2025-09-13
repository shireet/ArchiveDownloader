using MediatR;

namespace AwesomeFiles.BLL.Services.GetArchive;

public sealed record GetArchiveRequest :  IRequest<GetArchiveResponse>
{
    public Guid Id { get; }

    public GetArchiveRequest(Guid id)
    {
        Id = id;
    }
}