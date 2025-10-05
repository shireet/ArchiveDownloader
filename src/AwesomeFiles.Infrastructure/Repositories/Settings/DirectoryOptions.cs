namespace AwesomeFiles.Infrastructure.Repositories.Settings;

public record DirectoryOptions
{
    public required string ArchivePath { get; init; } = string.Empty;
    public required string FilesPath { get; init; } = string.Empty;
}