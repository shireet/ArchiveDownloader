namespace AwesomeFiles.Presentation.Models.Dtos;

public class StartArchiveResponse : ResponseBase
{
    public Guid? Id { get; init; }
    public StartArchiveResponse(string? errorMessage) : base(errorMessage) { }

    public StartArchiveResponse(Guid? id)
    {
        Id = id;
    }
}