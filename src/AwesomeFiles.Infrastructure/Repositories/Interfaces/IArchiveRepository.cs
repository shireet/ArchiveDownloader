namespace AwesomeFiles.Infrastructure.Repositories.Interfaces;

public interface IArchiveRepository
{
    Task<FileStream?> TryGetArchiveAsync(Guid id, CancellationToken cancellationToken);
    
    Task AddArchiveAsync(FileStream archive, Guid archiveId, CancellationToken cancellationToken);
}