using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;

namespace AnkietyUW.Services.Controllers.AdminControllers
{
    public class UsersController : BaseAdminController
    {
        //dodawnie uzytkownika do testu
        //wypisanie uzytkownikow 
        //modyfikacja uzytkownika
        //wyslanie maila o dowolnej tresci do uzytkownika
        public UsersController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
