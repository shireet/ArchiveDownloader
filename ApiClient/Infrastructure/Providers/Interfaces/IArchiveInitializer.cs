using ApiClient.Infrastructure.Models.Dtos;

namespace ApiClient.Infrastructure.Providers.Interfaces;

public interface IArchiveInitializer
{
    Task<StartArchiveResponse> CreateArchiveAsync(List<string> fileNames, CancellationToken cancellationToken);
}