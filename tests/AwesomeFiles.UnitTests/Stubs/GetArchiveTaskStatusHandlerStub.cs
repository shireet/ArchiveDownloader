using AwesomeFiles.BLL.Services.GetArchiveTaskStatus;
using AwesomeFiles.DAL.Interfaces;
using Moq;

namespace AwesomeFiles.UnitTests.Stubs;

public class GetArchiveTaskStatusHandlerStub : GetArchiveTaskStatusHandle
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