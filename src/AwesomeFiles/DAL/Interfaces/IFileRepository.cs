namespace AwesomeFiles.DAL.Interfaces;

public interface IFileRepository
{
    Task<List<string>> GetAllNamesAsync(CancellationToken cancellationToken);
    Task<Dictionary<string, FileStream>> GetFilesAsync(List<string> fileName, CancellationToken cancellationToken);
}