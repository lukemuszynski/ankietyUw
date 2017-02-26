using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnkietyUW.Contracts.TestDto.DataTransferObjects;
using AnkietyUW.Contracts.TestDto.ViewModels;
using AnkietyUW.DataLayer.Entities;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

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
                var list = await UnitOfWork.TestRepository.GetAllTests();
                var vmList = Mapper.Map<ICollection<Test>, ICollection<AllTestsViewModel>>(list);
                return new OkObjectResult(vmList);
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

        [HttpPost("InviteUsers")]
        public async Task<IActionResult> InviteUsers([FromBody]InviteUsersToTestDto inviteUsersToTestDto)
        {

            foreach (var emailAddress in inviteUsersToTestDto.EmailAddressList)
            {


                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("katarzyna.wojtkowska@badanie.emocje.uw", "Katarzyna Wojtkowska");
                var subject = "Rejestracja do badania";
                var to = new EmailAddress(emailAddress);
                var plainTextContent = "Witam serdecznie, proszę o rejestrację do badania na stronie: http://ankietyuwaspcore.azurewebsites.net/#/user-register/" + emailAddress;
                var htmlContent = "<p><h4>Witam serdecznie,</h4> Proszę o rejestrację do badania na poniższej stronie: </p> <a href=\"" + "http://ankietyuwaspcore.azurewebsites.net/#/user-register/" + emailAddress + "\">Link do rejestracji</a><h4>Pozdrawiam,</h4><h4>Katarzyna Wojtkowska</h4>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);


            }


            return Ok();
        }

    }
}


