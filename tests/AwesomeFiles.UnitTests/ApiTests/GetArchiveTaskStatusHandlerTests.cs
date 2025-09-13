using AwesomeFiles.BLL.Exceptions;
using AwesomeFiles.BLL.Extensions;
using AwesomeFiles.DAL.Entities;
using AwesomeFiles.UnitTests.Extensions;
using AwesomeFiles.UnitTests.Fakers;
using AwesomeFiles.UnitTests.Stubs;
using FluentAssertions;

namespace AwesomeFiles.UnitTests.ApiTests;

public class GetArchiveTaskStatusHandlerTests
{
    [Fact]
    public async Task Handle_GetArchiveTaskStatus_ReturnsStatus()
    {
        //Arrange
        var request = GetArchiveTaskStatusRequestFaker.Generate();
        var expectedResult = GetArchiveTaskStatusResponseFaker.Generate().WithId(request.Id);
        
        var stub = GetArchiveTaskStatusHandlerStub.Create();
        stub.ArchiveTaskStatusRepositoryMock.TryGetAsync(
            request.Id,
            new ArchiveTaskStatusEntity
            {
                Id = request.Id,
                Status = expectedResult.Status.ToDallArchiveStatusEnum(),
                CreatedAt = expectedResult.CreatedAt,
                CompletedAt = expectedResult.CompletedAt,
                TaskErrorMessage = expectedResult.TaskErrorMessage,
            }
            );
        //Act
        var result = await stub.Handle(request, CancellationToken.None);
        
        //Assert
        result.Should().BeEquivalentTo(expectedResult);
        result.Exception.Should().BeNull();
        
        stub.VerifyAll();
        stub.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task Handle_GetArchiveTaskStatus_ThrowsExceptionWhenArchiveNotFound()
    {
        //Arrange
        var request = GetArchiveTaskStatusRequestFaker.Generate();
        var exception = new StatusWasNotFoundException(request.Id);
        
        var stub = GetArchiveTaskStatusHandlerStub.Create();
        stub.ArchiveTaskStatusRepositoryMock.TryGetAsync(request.Id);
        
        //Act
        var response = await stub.Handle(request, CancellationToken.None);
        
        //Assert
        response.Exception.Should().BeOfType<StatusWasNotFoundException>().And.BeEquivalentTo(exception);
        
        stub.VerifyAll();
        stub.VerifyNoOtherCalls();
    }
}