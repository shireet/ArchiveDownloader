using System.Collections.Concurrent;
using AwesomeFiles.Infrastructure.Repositories.Entities;
using AwesomeFiles.Infrastructure.Repositories.Interfaces;

namespace AwesomeFiles.Infrastructure.Repositories.Implementations;

public class ArchiveTaskStatusRepository : IArchiveTaskStatusRepository
{
    private readonly ConcurrentDictionary<Guid, ArchiveTaskStatusEntity> _archiveTaskStatuses = new();

    public async Task<ArchiveTaskStatusEntity?> TryGetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_archiveTaskStatuses.GetValueOrDefault(id));
    }

    public async Task UpsertAsync(ArchiveTaskStatusEntity statusEntity, CancellationToken cancellationToken)
    {
        await Task.FromResult(_archiveTaskStatuses[statusEntity.Id] = statusEntity);
    }
}