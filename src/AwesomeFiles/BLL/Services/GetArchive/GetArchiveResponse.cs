namespace AwesomeFiles.BLL.Services.GetArchive;

public sealed class GetArchiveResponse : ResponseBase
{
    public FileStream? Archive { get; }

    public GetArchiveResponse(FileStream archive)
    {
        Archive = archive;
    }
    public GetArchiveResponse(Exception exception) : base(exception) { }
}