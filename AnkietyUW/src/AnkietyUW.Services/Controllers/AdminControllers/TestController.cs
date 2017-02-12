using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.Contracts.TestDto.DataTransferObjects;
using AnkietyUW.Contracts.TestDto.ViewModels;
using AnkietyUW.DataLayer.Entities;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnkietyUW.Services.Controllers.AdminControllers
{
    [Route("Tests")]
    public class TestController : BaseAdminController
    {

        //Tworzenie nowego testu, wraz z wypelnieniem dni w ktore sa badania, i godzinami
        //modyfikowanie testow
        //wyswietlanei wszystkich testow
        public TestController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateNewTest([FromBody]CreateTestDto createTestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
     
            try
            {
                Test test = Mapper.Map<CreateTestDto, Test>(createTestDto);
                
                await UnitOfWork.TestRepository.AddTest(test);

                await UnitOfWork.SaveChangesAsync();

                var testViewModel = Mapper.Map<Test, AllTestsViewModel>(test);

                var jsonRet = new CreatedResult("CreateNewTest", testViewModel);
                return jsonRet;
            }
            catch (Exception e)
            {
                return new JsonResult(e.ToString());

            }
        }

        [HttpGet("Show/{id}")]
        public async Task<IActionResult> ShowTests(string id)
        {
            try
            {
                var test = await UnitOfWork.TestRepository.GetTest(new Guid(id));
                return Ok(test);
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
            
           
        }


    }
}
