using ApiClient.Infrastructure.Models.Dtos;

namespace ApiClient.Infrastructure.Providers.Interfaces;

public interface IFileProvider
{
    Task<GetAllFilesResponse> GetFilesAsync(CancellationToken cancellationToken);
    Task<Stream?> DownloadArchiveAsync(Guid id, CancellationToken cancellationToken);
}