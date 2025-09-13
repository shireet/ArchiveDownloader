using AwesomeFiles.DAL.Interfaces;
using Moq;

namespace AwesomeFiles.UnitTests.Extensions;

public static class FileRepositoryExtension
{
    public static Mock<IFileRepository> GetAllNamesAsync(
        this Mock<IFileRepository> repository,
        List<string> fileNames)
    {
        repository.Setup(r => r.GetAllNamesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(fileNames);
        return repository;
    }
}