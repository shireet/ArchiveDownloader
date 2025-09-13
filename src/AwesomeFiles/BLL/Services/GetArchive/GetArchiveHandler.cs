using AwesomeFiles.BLL.Exceptions;
using AwesomeFiles.DAL.Interfaces;
using MediatR;

namespace AwesomeFiles.BLL.Services.GetArchive;

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