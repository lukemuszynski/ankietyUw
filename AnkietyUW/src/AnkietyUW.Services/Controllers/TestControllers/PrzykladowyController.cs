using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.Contracts.Przyklad.DataTransferObjects;
using AnkietyUW.Contracts.Przyklad.ViewModels;
using AnkietyUW.DataLayer.Entities;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnkietyUW.Services.Controllers.TestControllers
{
    
    public class PrzykladowyController : BaseUserController
    {
        public PrzykladowyController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpPost]
        [Route("Przyklad/CreatePrzyklad")]
        public async Task<IActionResult> CreatePrzyklad([FromBody] CreatePrzykladDto createPrzykladDto)
        {

            Przyklad przyklad = Mapper.Map<CreatePrzykladDto, Przyklad>(createPrzykladDto);
            try
            {
                ///jaki magic typu zapisanie do bazy danych:
                przyklad = await DoSomethingOnPrzyklad(przyklad);
                PrzykladViewModel returnObjPrzykladViewModel = Mapper.Map<Przyklad, PrzykladViewModel>(przyklad);
                var res = new JsonResult(returnObjPrzykladViewModel);
                res.StatusCode = 203;
                return res;
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.ToString());
            }


        }

        private async Task<Przyklad> DoSomethingOnPrzyklad(Przyklad przyklad)
        {
            przyklad.UkrytaLiczbaPrzykladow = przyklad.LiczbaPrzykladow + 123;
            return przyklad;
        }

    }
}
