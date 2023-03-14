using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersExample.Filters
{
    public class ResultFilter
    {
        [AttributeUsage(AttributeTargets.All)]
        public class ResultFilterAttribute : Attribute, IResultFilter
        {
            public void OnResultExecuted(ResultExecutedContext context)
            {
                var id = context.RouteData.Values["id"];
                if (id != null)
                {
                    Debug.WriteLine("Result Filter");
                }

                var response = new
                {
                    statusCode = 200,
                    message = "Fetching id ",
                    data = id
                };
                Debug.WriteLine(response);


                //return new ObjectResult(response);
            }

            public void OnResultExecuting(ResultExecutingContext context)
            {
                //throw new NotImplementedException();
            }
        }
    }
}
