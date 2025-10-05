using AwesomeFiles.Application.Services.StartArchive;
using AwesomeFiles.Infrastructure.Repositories.Interfaces;
using Moq;

namespace AwesomeFiles.UnitTests.Stubs;

public class StartArchiveHandlerStub : StartArchiveHandler
{
    public Mock<IFileRepository> FileRepository;
    public Mock<IArchiveRepository> ArchiveRepository;
    public Mock<IArchiveTaskStatusRepository> ArchiveTaskStatusRepository;

    public StartArchiveHandlerStub(
        Mock<IFileRepository> fileRepository,
        Mock<IArchiveRepository> archiveRepository,
        Mock<IArchiveTaskStatusRepository> archiveTaskStatusRepository)
        : base(fileRepository.Object, archiveRepository.Object, archiveTaskStatusRepository.Object)
    {
        FileRepository =  fileRepository;
        ArchiveRepository = archiveRepository;
        ArchiveTaskStatusRepository = archiveTaskStatusRepository;
    }

    public static StartArchiveHandlerStub Create()
    {
        return new StartArchiveHandlerStub(
            new Mock<IFileRepository>(),
            new Mock<IArchiveRepository>(),
            new Mock<IArchiveTaskStatusRepository>()
        );
    }
    public void VerifyAll()
    {
        FileRepository.VerifyAll();
        ArchiveRepository.VerifyAll();
        ArchiveTaskStatusRepository.VerifyAll();
    } 
    
    public void VerifyNoOtherCalls()
    {
        FileRepository.VerifyAll();
        ArchiveRepository.VerifyAll();
        ArchiveTaskStatusRepository.VerifyAll();
    } 
}