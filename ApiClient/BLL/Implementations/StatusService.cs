using ApiClient.BLL.Interfaces;
using ApiClient.Infrastructure.Providers.Interfaces;
using ArchiveStatus = ApiClient.Infrastructure.Models.Enums.ArchiveStatus;

namespace ApiClient.BLL.Implementations;

public class StatusService(IArchiveStatusProvider archiveStatusProvider) : IStatusService
{
    public async Task<ArchiveStatus> GetStatusAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await archiveStatusProvider.GetArchiveStatusAsync(id, cancellationToken);
        return !response.Successful ? throw new Exception(response.ErrorMessage) : (ArchiveStatus)response.Status!;
    }

    public async Task WaitForCompletionAsync(Guid id, TimeSpan pollingInterval, int maxAttempts, CancellationToken cancellationToken)
    {
        for (var i = 0; i < maxAttempts; i++)
        {
            var statusResponse = await archiveStatusProvider.GetArchiveStatusAsync(id, cancellationToken);
                
            switch (statusResponse.Status)
            {
                case ArchiveStatus.Completed:
                    return;
                case ArchiveStatus.Failed:
                    throw new Exception($"Archive creation failed: {statusResponse.ErrorMessage}");
                default:
                    await Task.Delay(pollingInterval, cancellationToken);
                    break;
            }
        }
        
        throw new TimeoutException("Archive creation timed out");
    }
}