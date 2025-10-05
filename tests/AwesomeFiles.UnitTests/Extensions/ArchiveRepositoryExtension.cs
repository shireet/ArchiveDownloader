using AwesomeFiles.Infrastructure.Repositories.Interfaces;
using Moq;

namespace AwesomeFiles.UnitTests.Extensions;

public static class ArchiveRepositoryExtension
{
    public static Mock<IArchiveRepository> TryGetArchiveReturnsFile(
        this Mock<IArchiveRepository> repository,
        Guid id,
        FileStream? file = null)
    {
        repository.Setup(r => r.TryGetArchiveAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(file);
        return repository;
    }
}