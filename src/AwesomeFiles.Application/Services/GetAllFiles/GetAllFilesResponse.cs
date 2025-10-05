namespace AwesomeFiles.Application.Services.GetAllFiles;

public sealed class GetAllFilesResponse : ResponseBase
{
    public List<string>? FileNames { get; }

    public GetAllFilesResponse(List<string> fileNames)
    {
        FileNames = fileNames.Select(x => x).ToList();
    }

    public GetAllFilesResponse(Exception exception) : base(exception){ }
}