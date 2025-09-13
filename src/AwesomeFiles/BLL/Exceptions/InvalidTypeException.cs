namespace AwesomeFiles.BLL.Exceptions;

public class InvalidTypeException(string type) : BusinessException
{
    public override string Message => $"Type: {type} is invalid";
}
