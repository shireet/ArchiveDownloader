namespace AwesomeFiles.Application.Services.StartArchive;

public sealed class StartArchiveResponse : ResponseBase
{
    public Guid? Id { get; }

    public StartArchiveResponse(Guid id)
    {
        Id = id;
    }
    public StartArchiveResponse(Exception exception) : base(exception){ }
}