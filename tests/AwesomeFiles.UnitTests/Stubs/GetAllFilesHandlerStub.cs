using AwesomeFiles.Application.Services.GetAllFiles;
using AwesomeFiles.Infrastructure.Repositories.Interfaces;
using Moq;

namespace AwesomeFiles.UnitTests.Stubs;

public class GetAllFilesHandlerStub : GetAllFilesHandler
{
    public Mock<IFileRepository> FileRepositoryMock;

    public GetAllFilesHandlerStub(Mock<IFileRepository> fileRepositoryMock)
        : base(fileRepositoryMock.Object)
    {
        FileRepositoryMock = fileRepositoryMock;
    }
    
    public static GetAllFilesHandlerStub Create()
    {
        return new GetAllFilesHandlerStub(new Mock<IFileRepository>());
    }
    
    public void VerifyAll()
    {
        FileRepositoryMock.VerifyAll();
    } 
    
    public void VerifyNoOtherCalls()
    {
        FileRepositoryMock.VerifyNoOtherCalls();
    } 
}