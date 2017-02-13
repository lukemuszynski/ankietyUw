using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using AnkietyUW.Services.Infrastructure.Filters;
using AnkietyUW.Utilities;
using Microsoft.AspNetCore.Cors;

namespace AnkietyUW.Services.Infrastructure.BaseControllers
{
  
    [UserFilter]
    [PassToControllerFilter]
    public class BaseUserController : Controller
    {
        public BaseUserController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        protected IUnitOfWork UnitOfWork { get; set; }
        public Guid SecretId { get; set; }
        public Guid TestTimeId { get; set; }
        public Guid UserId { get; set; }
        public int SeriesNumber { get; set; }   
    }
}
