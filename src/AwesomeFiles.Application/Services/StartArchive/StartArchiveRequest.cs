using MediatR;

namespace AwesomeFiles.Application.Services.StartArchive;

public sealed record StartArchiveRequest : IRequest<StartArchiveResponse>
{
    public List<string> Files { get; } = [];

    public StartArchiveRequest(List<string> files)
    {
        Files = files.Select(x => x).ToList(); 
    }
}