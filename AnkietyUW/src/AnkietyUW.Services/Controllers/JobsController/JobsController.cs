using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;

namespace AnkietyUW.Services.Controllers.JobsController
{
    public class JobsController : BaseAdminController
    {
        //wysylanie maili do wszystkich osob z danego badania
        public JobsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
