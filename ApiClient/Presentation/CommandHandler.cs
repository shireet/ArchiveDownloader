using ApiClient.BLL.Interfaces;
using System.CommandLine;


namespace ApiClient.Presentation;

public class CommandHandler(
    IFileService fileService,
    IArchiveService archiveService,
    IStatusService statusService)
{
    public Command CreateListCommand()
     {
         var command = new Command("list", "Get list of available files");
         command.SetAction(async (_, cancellationToken)  =>
         {
             try
             {
                 var files = await fileService.GetFilesAsync(cancellationToken);
                 Console.WriteLine(string.Join(" ", files));
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Error: {ex.Message}");
                 return 1;
             }
             return 0;
         });
         
         return command;
     }
    
    public Command CreateArchiveCommand()
    {
        Option<List<string>> fileOption = new("--files")
        {
            Description = "The file to read and display on the console.",
            AllowMultipleArgumentsPerToken = true,
            Required = true
        };
        var command = new Command("create-archive", "Create archive from files")
        {
            fileOption
        };
        
        command.SetAction(async (parseResult, cancellationToken) =>
        {
            try
            {
                var fileNames = parseResult.GetValue(fileOption);
                var id = await archiveService.CreateArchiveAsync(fileNames!, cancellationToken);
                Console.WriteLine($"Create archive task is started, id: {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }
            return 0;
        });
            
        return command;
    }
    
    public Command CreateStatusCommand()
    {
        Option<Guid> inputGuid = new("--id")
        {
            Description = "id of the archive status",
            Required = true
        };
        var command = new Command("status", "Check status of archive task")
        {
            inputGuid
        };
        command.SetAction(async (parseResult, cancellationToken) =>
        {
            try
            {
                var id = parseResult.GetValue(inputGuid);
                var status = await statusService.GetStatusAsync(id, cancellationToken);
                Console.WriteLine(status);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }
            return 0;
        });
        return command;
    }

    public Command CreateDownloadCommand(string path)
    {
        Option<Guid> inputGuid = new("--id")
        {
            Description = "id of the archive to download",
            Required = true
        };
        var command = new Command("download", "Download archive")
        {
            inputGuid
        };
        command.SetAction(async (parseResult, cancellationToken) =>
        {
            try
            {
                var id = parseResult.GetValue(inputGuid);
                var stream = await archiveService.DownloadArchiveAsync(id, cancellationToken);
                var directory = Path.GetFullPath(path);
                Directory.CreateDirectory(directory);
                var filePath = Path.Combine(directory, $"archive_{id}.zip");
                await using var fileStream = File.Create(filePath);
                await stream!.CopyToAsync(fileStream, cancellationToken);
                Console.WriteLine($"Archive downloaded to: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }

            return 0;
        });
        return command;
    }
    
    public Command CreateAutoArchiveCommand(string path)
    {
        Option<List<string>> inputFiles = new("--files")
        {
            Description = "files to archive",
            AllowMultipleArgumentsPerToken = true,
            Required = true
        };
        
        var command = new Command("auto-archive", "Create archive, wait for completion, and download")
        {
            inputFiles
        };

        command.SetAction(async (parseResult, cancellationToken) =>
        {
            try
            {
                var files = parseResult.GetValue(inputFiles);
                await archiveService.CreateAndDownloadArchiveAsync(
                    files!.ToList(), 
                    path, 
                    cancellationToken);
                Console.WriteLine($"Archive created and downloaded to: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }
            return 0;
        });
        return command;
    }
}