namespace AwesomeFiles.Domain.Exceptions;

public class ArchiveNotFoundExeption(Guid id) : BusinessException
{
    public override string Message => $"Archive with id {id} was not found";
}