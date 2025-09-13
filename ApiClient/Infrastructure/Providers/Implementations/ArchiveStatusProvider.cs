using ApiClient.Infrastructure.HttpClients.Interfaces;
using ApiClient.Infrastructure.Mappers;
using ApiClient.Infrastructure.Models.Dtos;
using ApiClient.Infrastructure.Providers.Interfaces;

namespace ApiClient.Infrastructure.Providers.Implementations;

public class ArchiveStatusProvider(IAwesomeFilesHttpClient httpClient) : IArchiveStatusProvider
{
    private const string ApiPath = "/api/v1/AwesomeFiles";

    public async Task<ArchiveTaskStatusResponse> GetArchiveStatusAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetAsync<ArchiveTaskStatusResponse>(ApiPath + "/GetArchiveTaskStatus/" + id, cancellationToken);
        return response;
    }
}