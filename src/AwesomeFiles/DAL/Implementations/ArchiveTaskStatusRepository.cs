using System.Collections.Concurrent;
using AwesomeFiles.DAL.Entities;
using AwesomeFiles.DAL.Interfaces;

namespace AwesomeFiles.DAL.Implementations;

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