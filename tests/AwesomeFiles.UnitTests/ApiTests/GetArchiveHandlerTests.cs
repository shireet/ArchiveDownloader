using AwesomeFiles.BLL.Exceptions;
using AwesomeFiles.BLL.Services.GetArchive;
using AwesomeFiles.UnitTests.Extensions;
using AwesomeFiles.UnitTests.Fakers;
using AwesomeFiles.UnitTests.Stubs;
using FluentAssertions;

namespace AwesomeFiles.UnitTests.ApiTests;

public class GetArchiveHandlerTests
{
    [Fact]
    public async Task Handle_GetArchive_ReturnArchive()
    {
        //Arrange
        var expectedResponse = GetArchiveResponseFaker.Generate();
        var request = GetArchiveRequestFaker.Generate();

        var stub = GetArchiveHandlerStud.Create();
        stub.ArchiveRepositoryMock.TryGetArchiveReturnsFile(request.Id, expectedResponse.Archive!);
        
        //Act
        var response = await stub.Handle(request, CancellationToken.None);
        
        //Assert
        response.Archive.Should().BeSameAs(expectedResponse.Archive);
        response.Exception.Should().BeNull();

        stub.VerifyAll();
        stub.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task Handle_GetArchive_ReturnNullWhenArchiveNotFound()
    {
        //Arrange
        var request = GetArchiveRequestFaker.Generate();
        var exception = new ArchiveNotFoundExeption(request.Id);
        
        var stub = GetArchiveHandlerStud.Create();
        stub.ArchiveRepositoryMock.TryGetArchiveReturnsFile(request.Id);
        
        //Act
        var response = await stub.Handle(request, CancellationToken.None);
        
        //Assert
        response.Exception.Should().BeOfType<ArchiveNotFoundExeption>().And.BeEquivalentTo(exception);
        response.Archive.Should().BeNull();
        
        stub.VerifyAll();
        stub.VerifyNoOtherCalls();
    }
}