using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AnkietyUW.Services.Infrastructure.BaseControllers
{
    
    public class BaseAdminController : Controller
    {
        protected Guid SecretId { get; set; }
        protected Guid TestTimeId { get; set; }
        protected Guid UserId { get; set; }


    }
}
