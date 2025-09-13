using ApiClient.BLL.Models;
using ApiClient.Infrastructure.Models.Enums;

namespace ApiClient.BLL.Interfaces;

public interface IStatusService
{
    Task<ArchiveStatus> GetStatusAsync(Guid id, CancellationToken cancellationToken);
    Task WaitForCompletionAsync(Guid id, TimeSpan pollingInterval, int maxAttempts, CancellationToken cancellationToken);
}