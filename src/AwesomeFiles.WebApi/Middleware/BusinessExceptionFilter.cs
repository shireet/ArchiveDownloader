using AwesomeFiles.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AwesomeFiles.WebApi.Middleware;

public class BusinessExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not BusinessException businessException) return;
        var response = context.HttpContext.Response;
        response.StatusCode = 400;
        context.ExceptionHandled = true;
        context.Result = new ObjectResult(businessException.Message);
    }
}