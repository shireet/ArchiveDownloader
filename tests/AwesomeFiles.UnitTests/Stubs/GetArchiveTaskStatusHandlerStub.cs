using AwesomeFiles.Application.Services.GetArchiveTaskStatus;
using AwesomeFiles.Infrastructure.Repositories.Interfaces;
using Moq;

namespace AwesomeFiles.UnitTests.Stubs;

public class GetArchiveTaskStatusHandlerStub : GetArchiveTaskStatusHandler
{
    public Mock<IArchiveTaskStatusRepository> ArchiveTaskStatusRepositoryMock;

    public GetArchiveTaskStatusHandlerStub(Mock<IArchiveTaskStatusRepository> archiveTaskStatusRepositoryMock)
        : base(archiveTaskStatusRepositoryMock.Object)
    {
        ArchiveTaskStatusRepositoryMock = archiveTaskStatusRepositoryMock;
    }

    public static GetArchiveTaskStatusHandlerStub Create()
    {
        return new GetArchiveTaskStatusHandlerStub(new Mock<IArchiveTaskStatusRepository>());
    }
    
    public void VerifyAll()
    {
        ArchiveTaskStatusRepositoryMock.VerifyAll();
    } 
    
    public void VerifyNoOtherCalls()
    {
        ArchiveTaskStatusRepositoryMock.VerifyNoOtherCalls();
    } 
}