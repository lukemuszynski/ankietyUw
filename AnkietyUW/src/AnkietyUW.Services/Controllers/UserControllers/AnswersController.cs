using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;
using AnkietyUW.DataLayer.Entities;
using AnkietyUW.DataLayer.Repository.AnswerRepository;
using AnkietyUW.DataLayer.Repository.SecretRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnkietyUW.Utilities;
using AnkietyUW.Contracts.AnswerDto.DataTransferObjects;
using AutoMapper;
using AnkietyUW.Contracts.AnswerDto.ViewModels;

namespace AnkietyUW.Services.Controllers.UserControllers
{
    [Route("Answers")]
    public class AnswersController : BaseUserController
    {
        //Metoda do zapisu odpowiedzi z ankiety
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveAnswerAsync([FromBody]AnswerDto answerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Answer answer = Mapper.Map<AnswerDto, Answer>(answerDto);
            answer.UserId = UserId.ToString();
            answer.DateTime = DateTime.UtcNow;
            answer.SeriesNumber = SeriesNumber;
            answer.TestId = TestTimeId.ToString();
            try
            {
                answer.Test = await UnitOfWork.Context.Tests.FirstOrDefaultAsync(p => p.Id == TestTimeId.ToString());
                answer.User = await UnitOfWork.Context.Users.FirstOrDefaultAsync(p => p.Id == UserId.ToString());
                await UnitOfWork.SecretRepository.DeleteSecret(SecretId);
                await UnitOfWork.AnswerRepository.SaveAnswer(answer);
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
            
            return Ok();

        }

        //Metoda do pobrania pytań z tokena
        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            QuestionsForUser questions = new QuestionsForUser();
            try {
                questions.questions = QuestionProvider.QuestionsForSeriesNumber(SeriesNumber);
            }
            catch(Exception ex)
            {
                var k = new JsonResult(ex);
                k.StatusCode = 500;
                return k;
            }
            
            return Ok(questions);
        }
        
        public AnswersController(IUnitOfWork unitOfWork, IQuestionsProvider questionProvider) : base(unitOfWork)
        {
            QuestionProvider = questionProvider;
        }

        protected IQuestionsProvider QuestionProvider { get; set; }



    }
}
