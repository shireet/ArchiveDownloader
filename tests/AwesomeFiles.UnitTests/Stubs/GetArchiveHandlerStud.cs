using AwesomeFiles.Application.Services.GetArchive;
using AwesomeFiles.Infrastructure.Repositories.Interfaces;
using Moq;

namespace AwesomeFiles.UnitTests.Stubs;

public class GetArchiveHandlerStud : GetArchiveHandler
{
    public Mock<IArchiveRepository> ArchiveRepositoryMock;

    public GetArchiveHandlerStud(Mock<IArchiveRepository> archiveRepositoryMock)
        : base(archiveRepositoryMock.Object)
    {
        ArchiveRepositoryMock = archiveRepositoryMock;
    }

    public static GetArchiveHandlerStud Create()
    {
        return new GetArchiveHandlerStud(new Mock<IArchiveRepository>());
    }
    public void VerifyAll()
    {
        ArchiveRepositoryMock.VerifyAll();
    } 
    
    public void VerifyNoOtherCalls()
    {
        ArchiveRepositoryMock.VerifyNoOtherCalls();
    } 
}