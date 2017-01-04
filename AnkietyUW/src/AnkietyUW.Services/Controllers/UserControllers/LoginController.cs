using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;

namespace AnkietyUW.Services.Controllers.UserControllers
{
    public class LoginController : BaseUserController
    {
        //metoda do polaczenia uzytkownika z mailem przy pierwszej rejestracji
        public LoginController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }



    }
}
