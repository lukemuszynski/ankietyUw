﻿using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;

namespace AnkietyUW.Services.Controllers.AdminControllers
{
    public class AnswersController : BaseAdminController
    {
        //Wypisanie odpowiedzi do danego testu
        public AnswersController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

    }
}