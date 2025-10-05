namespace AwesomeFiles.Domain.Exceptions;

public class StatusWasNotFoundException(Guid id) : BusinessException
{
    public override string Message => $"Status with id {id} was not found";
}