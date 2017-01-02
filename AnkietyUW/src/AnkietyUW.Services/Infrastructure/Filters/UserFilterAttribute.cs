using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AnkietyUW.Utilities;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace AnkietyUW.Services.Infrastructure.Filters
{
    public class UserFilterAttribute : IAuthorizationFilter
    {
        private IJwtUtility Jwt { get; set; }

        public UserFilterAttribute(IJwtUtility jwt)
        {
            Jwt = jwt;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            StringValues jsonWebToken;
            context.HttpContext.Request.Headers.TryGetValue("token", out jsonWebToken);

            if (jsonWebToken.Count == 0)
            {
                context.Result = new BadRequestResult();
                return;
            }

            var claims = Jwt.Decode(jsonWebToken[0]);
            foreach (var claim in claims)
            {
                context.HttpContext.Items.Add(claim.Key,claim.Value);
            }
          

        }
    }
}
