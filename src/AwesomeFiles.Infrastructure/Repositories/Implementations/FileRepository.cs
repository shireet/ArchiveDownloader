using AwesomeFiles.Infrastructure.Repositories.Interfaces;
using AwesomeFiles.Infrastructure.Repositories.Settings;

namespace AwesomeFiles.Infrastructure.Repositories.Implementations;

public class FileRepository : IFileRepository
{
    private readonly string _filesDirectory;

    public FileRepository(DirectoryOptions settings)
    {
        _filesDirectory = Directory.GetCurrentDirectory() + settings.FilesPath;
    }

    public Task<List<string>> GetAllNamesAsync(CancellationToken cancellationToken)
    {
        var files = Directory.GetFiles(_filesDirectory)
            .Select(Path.GetFileName)
            .Where(name => name != null)
            .Select(name => name!)
            .ToList();
            
        return Task.FromResult(files);
    }

    public async Task<Dictionary<string, FileStream>> GetFilesAsync(List<string> fileNames, CancellationToken cancellationToken)
    {
        var result = new Dictionary<string, FileStream>();

        foreach (var fileName in fileNames)
        {
            var filePath = Path.Combine(_filesDirectory, fileName);
            if (!File.Exists(filePath)) continue;
            var fileStream = File.OpenRead(filePath);
            result.Add(fileName, fileStream);
        }
        return await Task.FromResult(result);
    }
}