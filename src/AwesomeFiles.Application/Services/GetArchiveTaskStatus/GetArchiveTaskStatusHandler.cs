using AwesomeFiles.Application.Extensions;
using AwesomeFiles.Domain.Exceptions;
using AwesomeFiles.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace AwesomeFiles.Application.Services.GetArchiveTaskStatus;

public class GetArchiveTaskStatusHandler(
    IArchiveTaskStatusRepository archiveTaskStatusRepository) : IRequestHandler<GetArchiveTaskStatusRequest, GetArchiveTaskStatusResponse>
{
    public async Task<GetArchiveTaskStatusResponse> Handle(GetArchiveTaskStatusRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var status = await archiveTaskStatusRepository.TryGetAsync(request.Id, cancellationToken);
            return status == null ? new GetArchiveTaskStatusResponse(new StatusWasNotFoundException(request.Id)) : status.ToBll().ToResponse();
        }
        catch (Exception e)
        {
            throw;
        }
    }
}