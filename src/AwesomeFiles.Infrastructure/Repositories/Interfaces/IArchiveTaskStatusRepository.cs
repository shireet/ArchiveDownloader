using AwesomeFiles.Infrastructure.Repositories.Entities;

namespace AwesomeFiles.Infrastructure.Repositories.Interfaces;

public interface IArchiveTaskStatusRepository
{
    Task<ArchiveTaskStatusEntity?> TryGetAsync(Guid id, CancellationToken cancellationToken);
    Task UpsertAsync(ArchiveTaskStatusEntity statusEntity, CancellationToken cancellationToken);
}