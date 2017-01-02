using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AnkietyUW.Services.Infrastructure.BaseControllers
{

    public class BaseUserController : Controller
    {
        protected Guid SecretId { get; set; }
        protected Guid TestTimeId { get; set; }
        protected Guid UserId { get; set; }

        public BaseUserController()
        {
            SecretId = Guid.Parse(Request.HttpContext.Items["SecretId"] as string);
            SecretId = Guid.Parse(Request.HttpContext.Items["TestTimeId"] as string);
            SecretId = Guid.Parse(Request.HttpContext.Items["UserId"] as string);
        }
    }
}
