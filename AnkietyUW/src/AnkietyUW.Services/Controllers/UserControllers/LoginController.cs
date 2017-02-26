using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.Contracts.LoginDto.DataTransferObjects;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace AnkietyUW.Services.Controllers.UserControllers
{
    public class LoginController : Controller
    {
        private IUnitOfWork UnitOfWork { get; set; }
        //metoda do polaczenia uzytkownika z mailem przy pierwszej rejestracji
        public LoginController(IUnitOfWork unitOfWork) //: base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody]RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return Ok(2);
            }
            try
            {
                var user = await UnitOfWork.UserRepository.AddEmailToUserWithKey(registerDto.Key, registerDto.Email);

                if (user == null)
                    return Ok(2);

                await UnitOfWork.SaveChangesAsync();
                return Ok(1);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }


    }
}
