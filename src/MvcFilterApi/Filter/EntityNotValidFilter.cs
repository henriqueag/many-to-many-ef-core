using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MvcFilterApi.Exceptions;

namespace MvcFilterApi.Filter;

public class EntityNotValidFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is EntityNotValidException ex
            && context.Exception.GetType() == typeof(EntityNotValidException)
            && !context.ExceptionHandled)
        {
            var response = new
            {
                ex.Code,
                ex.Message,
                Errors = ex.Notifications.Select(x => new { x.PropertyName, x.Message }).ToArray()
            };

            context.Result = new ObjectResult(response);
            context.HttpContext.Response.StatusCode = 400;
            context.ExceptionHandled = true;
        }
    }
}