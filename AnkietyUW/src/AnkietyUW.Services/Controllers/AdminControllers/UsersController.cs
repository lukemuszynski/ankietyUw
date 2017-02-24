using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using AnkietyUW.Contracts.UsersDto;
using AnkietyUW.DataLayer.Entities;
using AutoMapper;

namespace AnkietyUW.Services.Controllers.AdminControllers
{
    [Route("Users")]
    public class UsersController : BaseAdminController
    {
        //dodawnie uzytkownika do testu
        //wypisanie uzytkownikow 
        //modyfikacja uzytkownika
        //wyslanie maila o dowolnej tresci do uzytkownika
        public UsersController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpPost("AddSingle")]
        public async Task<IActionResult> AddSingleUser([FromBody]AddSingleUserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                User user = Mapper.Map<AddSingleUserDto, User>(userDto);
                await UnitOfWork.UserRepository.AddUser(user);
                await UnitOfWork.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }

        [HttpPost("AddMultiple")]
        public async Task<IActionResult> AddMultipleUsers([FromBody]AddMultipleUsersDto usersDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new BadRequestObjectResult("Error: Invalid ModelState");

                var testId = Guid.Parse(usersDto.TestId);
                var test = await UnitOfWork.TestRepository.GetSingleTest(testId);

                if (test == null)
                    return new BadRequestObjectResult("Error: Test with given Id does not exist");

                ICollection<string> keys = usersDto.Keys;
                foreach (var key in keys)
                {
                    await UnitOfWork.UserRepository.AddUserByKey(key, testId);
                }

                await UnitOfWork.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }
    }
}
