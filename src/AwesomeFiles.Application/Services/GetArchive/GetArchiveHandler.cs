using AwesomeFiles.Domain.Exceptions;
using AwesomeFiles.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace AwesomeFiles.Application.Services.GetArchive;

public class GetArchiveHandler(
    IArchiveRepository archiveRepository) : IRequestHandler<GetArchiveRequest, GetArchiveResponse>
{
    public async Task<GetArchiveResponse> Handle(GetArchiveRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var archiveStream = await archiveRepository.TryGetArchiveAsync(request.Id, cancellationToken);
            return archiveStream == null ? new GetArchiveResponse(new ArchiveNotFoundExeption(request.Id)) : new GetArchiveResponse(archiveStream);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}