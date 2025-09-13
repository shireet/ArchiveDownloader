using AwesomeFiles.DAL.Interfaces;
using AwesomeFiles.DAL.Settings;

namespace AwesomeFiles.DAL.Implementations;

public class ArchiveRepository(DirectoryOptions settings) : IArchiveRepository
{
    private readonly string _archiveBasePath = Directory.GetCurrentDirectory() + settings.ArchivePath;
    
    public async Task<FileStream?> TryGetArchiveAsync(Guid id, CancellationToken cancellationToken)
    {
        var archivePath = Path.Combine(_archiveBasePath, $"{id}.zip");
        return await Task.FromResult(!File.Exists(archivePath) ? null : File.OpenRead(archivePath));
    }
    public async Task AddArchiveAsync(FileStream archiveStream, Guid archiveId, CancellationToken cancellationToken)
    {
        var fileName = $"{archiveId}.zip";
        var archivePath = Path.Combine(_archiveBasePath, fileName);
        
        if (archiveStream.CanSeek)
        {
            archiveStream.Position = 0;
        }

        await using var fileStream = File.Create(archivePath);
        await archiveStream.CopyToAsync(fileStream, cancellationToken);
    }
}