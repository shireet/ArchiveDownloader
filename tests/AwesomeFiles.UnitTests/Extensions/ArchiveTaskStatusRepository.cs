using AwesomeFiles.DAL.Entities;
using AwesomeFiles.DAL.Interfaces;
using Moq;


namespace AwesomeFiles.UnitTests.Extensions;

public static class ArchiveTaskStatusRepository
{
    public static Mock<IArchiveTaskStatusRepository> TryGetAsync(
        this Mock<IArchiveTaskStatusRepository> repository,
        Guid id,
        ArchiveTaskStatusEntity? entity = null)
    {
        repository.Setup(r => r.TryGetAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(entity);
        return repository;
    }
}