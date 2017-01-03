using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AnkietyUW.Utilities;
using Jose;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Serialization;

namespace AnkietyUW.Services.Infrastructure.Filters
{
    public class UserFilterAttribute : Attribute, IAuthorizationFilter
    {
        private IJwtUtility Jwt { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Jwt = context.HttpContext.RequestServices.GetService<IJwtUtility>();

            StringValues jsonWebToken;
            context.HttpContext.Request.Headers.TryGetValue("token", out jsonWebToken);

            if (jsonWebToken.Count == 0)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            try
            {
                var claims = Jwt.Decode(jsonWebToken[0]);

                foreach (var claim in claims)
                {
                    context.HttpContext.Items.Add(claim.Key, claim.Value);
                }
            }
            catch (IntegrityException e)
            {
                context.Result = new UnauthorizedResult();
                return;
                
            }

        }
    }
}
