namespace AwesomeFiles.Presentation.Models.Dtos;

public class GetAllFilesResponse : ResponseBase
{
    public List<string> FileNames { get; set; } = [];

    public GetAllFilesResponse(List<string> fileNames)
    {
        FileNames = fileNames;
    }
    public GetAllFilesResponse(string errorMessage) : base(errorMessage) { }

}