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
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> CreateNewTestAsync([FromBody]CreateTestDto testDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                Test test = Mapper.Map<CreateTestDto, Test>(testDto);

                await UnitOfWork.TestRepository.AddTest(test);

                await UnitOfWork.SaveChangesAsync();

                var testViewModel = Mapper.Map<Test, AllTestsViewModel>(test);

                return new OkObjectResult(testViewModel);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }

        public async Task<IActionResult> Index()
        {
            return await ShowTestsAsync();
        }

        [HttpGet("Show")]
        public async Task<IActionResult> ShowTestsAsync()
        {
            try
            {
                return new OkObjectResult( UnitOfWork.TestRepository.GetAllTests().Result );
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }

        [HttpGet("Show/{id}")]
        public async Task<IActionResult> ShowTestAsync(string id)
        {
            try
            {
                var test = await UnitOfWork.TestRepository.GetSingleTest(Guid.Parse(id));

                var testViewModel = Mapper.Map<Test, AllTestsViewModel>(test);

                return new OkObjectResult(testViewModel);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }


        [HttpPost("Update")]
        public async Task<IActionResult> UpdateTestAsync([FromBody]UpdateTestDto testDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                Test test = Mapper.Map<UpdateTestDto, Test>(testDto);

                await UnitOfWork.TestRepository.UpdateTest(test);

                await UnitOfWork.SaveChangesAsync();
                
                var testViewModel = Mapper.Map<Test, AllTestsViewModel>(test);

                return new OkObjectResult(testViewModel);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTestAsync(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                Test tempTest = new Test() {Id = Guid.Parse(id)};

                UnitOfWork.TestRepository.DeleteTest(tempTest);

                await UnitOfWork.SaveChangesAsync();

                return new OkResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }
    }
}
