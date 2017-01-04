using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace AnkietyUW.Services.Infrastructure.BaseControllers
{
    //dopisac filtr uwierzytelniajacy admina
    public class BaseAdminController : Controller
    {

        public BaseAdminController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        protected IUnitOfWork UnitOfWork { get; set; }

    }
}
