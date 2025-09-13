using AwesomeFiles.DAL.Entities;

namespace AwesomeFiles.DAL.Interfaces;

public interface IArchiveTaskStatusRepository
{
    Task<ArchiveTaskStatusEntity?> TryGetAsync(Guid id, CancellationToken cancellationToken);
    Task UpsertAsync(ArchiveTaskStatusEntity statusEntity, CancellationToken cancellationToken);
}