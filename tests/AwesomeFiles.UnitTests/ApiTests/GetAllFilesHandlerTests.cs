using AwesomeFiles.UnitTests.Extensions;
using AwesomeFiles.UnitTests.Fakers;
using AwesomeFiles.UnitTests.Stubs;
using FluentAssertions;


namespace AwesomeFiles.UnitTests.ApiTests;

public class GetAllFilesHandlerTests
{
    [Fact]
    public async Task Handle_GetAllFiles_ReturnsFileNames()
    {
        //Arrange
        var expectedResult = GetAllFilesResponseFaker.Generate();
        var request = GetAllFilesRequestFaker.Generate();

        var stub = GetAllFilesHandlerStub.Create();
        stub.FileRepositoryMock.GetAllNamesAsync(expectedResult.FileNames!);

        //Act
        var response = await stub.Handle(request,  CancellationToken.None);

        //Assert
        response.FileNames.Should().BeEquivalentTo(expectedResult.FileNames);
        response.Exception.Should().BeNull();

        stub.VerifyAll();
        stub.VerifyNoOtherCalls();
    }
}