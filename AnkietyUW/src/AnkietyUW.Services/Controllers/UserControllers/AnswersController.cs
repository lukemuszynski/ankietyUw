using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;
using AnkietyUW.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace AnkietyUW.Services.Controllers.UserControllers
{
    
    public class AnswersController : BaseUserController
    {

        //1. metoda do wyslania odpowiedzi na pytania, przed zapisaniem odpowiedzi usunac z tabeli secret rekord z odpowiednim UserId i SeriesNumber
        //2. metoda do pobrania pytan w zależności od danego tokena
        public IQuestionsProvider Qp { get; set; }
        //Wypisanie odpowiedzi do danego testu
        public AnswersController(IUnitOfWork unitOfWork, IQuestionsProvider qp) : base(unitOfWork)
        {
            Qp = qp;
        }


        [HttpGet("Answers")]
        public async Task<IActionResult> GetQuestsions()
        {
            return new JsonResult(Qp.QuestionsForSeriesNumber(SeriesNumber));
        }

    }
}
