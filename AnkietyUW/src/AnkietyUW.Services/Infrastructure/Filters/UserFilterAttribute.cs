using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace AnkietyUW.Services.Infrastructure.Filters
{
    public class UserFilterAttribute : IAuthorizationFilter
    {


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            StringValues jsonWebToken;
            context.HttpContext.Request.Headers.TryGetValue("token", out jsonWebToken);

            //TODO 


        }
    }
}
