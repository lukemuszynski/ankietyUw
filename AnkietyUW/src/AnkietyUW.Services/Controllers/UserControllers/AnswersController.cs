using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;

namespace AnkietyUW.Services.Controllers.UserControllers
{
    
    public class AnswersController : BaseUserController
    {

        //1. metoda do wyslania odpowiedzi na pytania, przed zapisaniem odpowiedzi usunac z tabeli secret rekord z odpowiednim UserId i SeriesNumber
        //2. metoda do pobrania pytan w zależności od danego tokena
        public AnswersController(IUnitOfWork unitOfWork): base(unitOfWork)
        {
            
        }


        
    }
}
