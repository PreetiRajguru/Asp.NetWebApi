using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FiltersExample.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public class ExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;             //context.Result = new OkObjectResult(new { err = true, errDesc = ex.Message});
            context.Result = new ObjectResult(new { err = true, errDesc = ex.Message })
            { StatusCode = 500 };
            Debug.WriteLine("Exception Thrown");
        }
    }
}
