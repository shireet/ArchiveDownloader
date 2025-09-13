using System.IO.Compression;
using AwesomeFiles.BLL.Exceptions;

namespace AwesomeFiles.BLL.Extensions;

public static class ArchiverExtension
{
    public static async Task<FileStream> ArchiveAsync(this Dictionary<string, FileStream> files, CancellationToken cancellationToken)
    {
        var tempFilePath = Path.GetTempFileName();
        var archiveFileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None, 4096, FileOptions.DeleteOnClose);

        try
        {
            using (var archive = new ZipArchive(archiveFileStream, ZipArchiveMode.Create, true))
            {
                foreach (var (fileName, fileStream) in files)
                {
                    if (fileStream.CanSeek)
                    {
                        fileStream.Position = 0;
                    }
                    var entry = archive.CreateEntry(fileName, CompressionLevel.Optimal);

                    await using var entryStream = entry.Open();
                    await fileStream.CopyToAsync(entryStream, cancellationToken);
                }
            }

            archiveFileStream.Position = 0;
            
            return archiveFileStream;
        }
        catch
        {
            await archiveFileStream.DisposeAsync();
            throw;
        }
    }
}
