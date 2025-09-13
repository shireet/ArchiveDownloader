using ApiClient.BLL.Models;
using ApiClient.Infrastructure.Models.Dtos;

namespace ApiClient.Infrastructure.Providers.Interfaces;

public interface IArchiveStatusProvider
{
    Task<ArchiveTaskStatusResponse> GetArchiveStatusAsync(Guid id, CancellationToken cancellationToken);
}