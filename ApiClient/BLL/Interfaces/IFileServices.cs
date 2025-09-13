namespace ApiClient.BLL.Interfaces;

public interface IFileService
{
    Task<List<string>> GetFilesAsync(CancellationToken cancellationToken);
}