using ApiClient.BLL.Interfaces;
using ApiClient.Infrastructure.Providers.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ApiClient.BLL.Implementations;

public class ArchiveService(
    IArchiveInitializer archiveInitializer,
    IStatusService statusService,
    IFileProvider fileProvider) : IArchiveService
{
    public async Task<Guid> CreateArchiveAsync(List<string> fileNames, CancellationToken cancellationToken)
    {
        var response = await archiveInitializer.CreateArchiveAsync(fileNames, cancellationToken);
        return !response.Successful ? throw new Exception(response.ErrorMessage) : (Guid)response.Id!;
    }

    public async Task<Stream?> DownloadArchiveAsync(Guid id, CancellationToken cancellationToken)
    {
        var response =  await fileProvider.DownloadArchiveAsync(id, cancellationToken);
        return response ?? throw new Exception("Archive not found");
    }

    public async Task<Guid?> CreateAndDownloadArchiveAsync(List<string> fileNames, string downloadPath, CancellationToken cancellationToken)
    {
        var id = await CreateArchiveAsync(fileNames, cancellationToken);
            
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.ApiClient.json")       //понимаю, так нельзя, но я ужe устал
            .Build();
            
        var pollingInterval = TimeSpan.FromMilliseconds(int.Parse(config["PollingIntervalMs"] ?? throw new InvalidOperationException()));
        var maxAttempts = int.Parse(config["MaxPollingAttempts"] ?? throw new InvalidOperationException());
            
        await statusService.WaitForCompletionAsync(id, pollingInterval, maxAttempts, cancellationToken);
            
        await using var stream = await DownloadArchiveAsync(id, cancellationToken);
        var filePath = Path.Combine(downloadPath, $"archive_{id}.zip");
            
        await using var fileStream = File.Create(filePath);
        await stream!.CopyToAsync(fileStream, cancellationToken);
            
        return id;
    }
}