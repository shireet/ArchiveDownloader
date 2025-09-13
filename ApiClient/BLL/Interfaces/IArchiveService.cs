namespace ApiClient.BLL.Interfaces;

public interface IArchiveService
{
    Task<Guid> CreateArchiveAsync(List<string> fileNames, CancellationToken cancellationToken);
    Task<Stream?> DownloadArchiveAsync(Guid id, CancellationToken cancellationToken);
    Task<Guid?> CreateAndDownloadArchiveAsync(List<string> fileNames, string downloadPath, CancellationToken cancellationToken);
}