using ApiClient.Infrastructure.HttpClients.Interfaces;
using ApiClient.Infrastructure.Models.Dtos;
using ApiClient.Infrastructure.Providers.Interfaces;

namespace ApiClient.Infrastructure.Providers.Implementations;

public class FileProvider(IAwesomeFilesHttpClient httpClient) : IFileProvider
{
    private const string ApiPath = "/api/v1/AwesomeFiles";

    public async Task<GetAllFilesResponse> GetFilesAsync(CancellationToken cancellationToken)
    {
        return await httpClient.GetAsync<GetAllFilesResponse>(ApiPath+"/GetAllFiles", cancellationToken);
    }

    public Task<Stream?> DownloadArchiveAsync(Guid id, CancellationToken cancellationToken)
    {
        return httpClient.GetStreamAsync(ApiPath+"/GetArchive/"+id, cancellationToken);
    }
}