using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.Services.Infrastructure.BaseControllers;

using Microsoft.AspNetCore.Mvc.Filters;

namespace AnkietyUW.Services.Infrastructure.Filters
{
    public class PassToControllerFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            (context.Controller as BaseUserController).SecretId = Guid.Parse(context.HttpContext.Items["SecretId"] as string);
            (context.Controller as BaseUserController).TestTimeId = Guid.Parse(context.HttpContext.Items["TestTimeId"] as string);
            (context.Controller as BaseUserController).UserId = Guid.Parse(context.HttpContext.Items["UserId"] as string);
            (context.Controller as BaseUserController).SeriesNumber = Int32.Parse(context.HttpContext.Items["SeriesNumber"] as string);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }
    }
}
