using AwesomeFiles.Application.Extensions;
using AwesomeFiles.Domain.Exceptions;
using AwesomeFiles.Infrastructure.Repositories.Entities;
using AwesomeFiles.Infrastructure.Repositories.Entities.Enums;
using AwesomeFiles.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace AwesomeFiles.Application.Services.StartArchive;

public class StartArchiveHandler( 
    IFileRepository fileRepository,
    IArchiveRepository archiveRepository,
    IArchiveTaskStatusRepository archiveTaskStatusRepository)
    : IRequestHandler <StartArchiveRequest, StartArchiveResponse>
{
    public async Task<StartArchiveResponse> Handle(StartArchiveRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var filesDictionary = await fileRepository.GetFilesAsync(request.Files, cancellationToken);
            if (filesDictionary.Count < request.Files.Count)
                return new StartArchiveResponse(new NoFilesWereFoundException(request.Files.Except(filesDictionary.Keys).ToList()));
            
            var id = Guid.NewGuid();
            var createdAt = DateTime.Now;

            await archiveTaskStatusRepository.UpsertAsync(
                new ArchiveTaskStatusEntity
                {
                    Id = id,
                    Status = ArchiveStatus.Pending,
                    CreatedAt = createdAt
                },
                cancellationToken
            );

            _ = Task.Run(async () =>
            {
                try
                {
                    await archiveTaskStatusRepository.UpsertAsync(
                        new ArchiveTaskStatusEntity
                        {
                            Id = id,
                            Status = ArchiveStatus.Processing,
                            CreatedAt = createdAt
                        },
                        CancellationToken.None
                    );

                    await using var archiveStream = await filesDictionary.ArchiveAsync(CancellationToken.None);
                    
                    await archiveRepository.AddArchiveAsync(archiveStream, id, CancellationToken.None);

                    await archiveTaskStatusRepository.UpsertAsync(
                        new ArchiveTaskStatusEntity
                        {
                            Id = id,
                            Status = ArchiveStatus.Completed,
                            CreatedAt = createdAt,
                            CompletedAt = DateTime.Now
                        },
                        CancellationToken.None
                    );
                }
                catch (Exception ex)
                {
                    await archiveTaskStatusRepository.UpsertAsync(
                        new ArchiveTaskStatusEntity
                        {
                            Id = id,
                            Status = ArchiveStatus.Failed,
                            TaskErrorMessage = ex.Message,
                            CreatedAt = createdAt,
                            CompletedAt = DateTime.Now
                        },
                        CancellationToken.None
                    );
                }
                finally
                {
                    foreach (var fileStream in filesDictionary.Values)
                    {
                        await fileStream.DisposeAsync();
                    }
                }

            }, cancellationToken);
               
            return new StartArchiveResponse(id);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}