using ApiClient.BLL.Interfaces;
using ApiClient.Infrastructure.Providers.Interfaces;

namespace ApiClient.BLL.Implementations;

public class FileService(IFileProvider fileProvider) : IFileService
{
    public async Task<List<string>> GetFilesAsync(CancellationToken cancellationToken)
    {
        var response =  await fileProvider.GetFilesAsync(cancellationToken);
        return !response.Successful ? throw new Exception(response.ErrorMessage) : [..response.FileNames];
    }
}