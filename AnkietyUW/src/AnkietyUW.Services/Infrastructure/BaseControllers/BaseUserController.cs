using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnkietyUW.Services.Infrastructure.Filters;
using AnkietyUW.Utilities;

namespace AnkietyUW.Services.Infrastructure.BaseControllers
{
    [UserFilter]
    public class BaseUserController : Controller
    {
        protected Guid SecretId { get; set; }
        protected Guid TestTimeId { get; set; }
        protected Guid UserId { get; set; }

        public BaseUserController()
        {
           
            SecretId = Guid.Parse(Request.HttpContext.Items["SecretId"] as string);
            TestTimeId = Guid.Parse(Request.HttpContext.Items["TestTimeId"] as string);
            UserId = Guid.Parse(Request.HttpContext.Items["UserId"] as string);
        }
    }
}
