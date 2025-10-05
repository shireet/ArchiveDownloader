namespace AwesomeFiles.Domain.Exceptions;

public class NoFilesWereFoundException(List<string> fileNames) : BusinessException
{
    public override string Message => $"Following files were not found: {string.Join(", ", fileNames)}";   
}