using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.Entities;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;

namespace AnkietyUW.Services.Controllers.AdminControllers
{
    public class TestController : BaseAdminController
    {

        //Tworzenie nowego testu, wraz z wypelnieniem dni w ktore sa badania, i godzinami
        //modyfikowanie testow
        //wyswietlanei wszystkich testow
        public TestController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork.TestRepository.AddTest(new Test());
            UnitOfWork.SaveChangesAsync();
        }

    }
}
