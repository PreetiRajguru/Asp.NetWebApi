using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersExample.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public class ActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var id = context.RouteData.Values["id"];
            /*if (id != null)
            {
                throw new Exception();
            }*/
            Debug.WriteLine($"Id entered : {id}");
            // pre-processing
            Debug.WriteLine("Action Filter executed");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Action Filter executing");
        }
    }
}
