using ApiClient.Infrastructure.HttpClients.Interfaces;
using ApiClient.Infrastructure.Models.Dtos;
using ApiClient.Infrastructure.Providers.Interfaces;

namespace ApiClient.Infrastructure.Providers.Implementations;

public class ArchiveInitializer(IAwesomeFilesHttpClient httpClient) : IArchiveInitializer
{
    private const string ApiPath = "/api/v1/AwesomeFiles";

    public async Task<StartArchiveResponse> CreateArchiveAsync(List<string> fileNames, CancellationToken cancellationToken)
    {
        var request = new StartArchiveRequest
        {
            FileNames = fileNames
        };
        var response = await httpClient.PostAsync<StartArchiveResponse>(ApiPath+"/StartArchive", request, cancellationToken);
        return response;
    }
}