using AwesomeFiles.BLL.Exceptions;
using AwesomeFiles.BLL.Extensions;
using AwesomeFiles.DAL.Interfaces;
using MediatR;

namespace AwesomeFiles.BLL.Services.GetArchiveTaskStatus;

public class GetArchiveTaskStatusHandle(
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