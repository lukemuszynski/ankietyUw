using System;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;
using AnkietyUW.DataLayer.Entities;
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

        protected IQuestionsProvider QuestionProvider { get; set; }

        public AnswersController(IUnitOfWork unitOfWork, IQuestionsProvider questionProvider) : base(unitOfWork)
        {
            QuestionProvider = questionProvider;
        }


        //Metoda do zapisu odpowiedzi z ankiety
        [HttpPost("Save")]
        //[Route]
        public async Task<IActionResult> SaveAnswerAsync([FromBody]AnswerDto answerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Answer answer = Mapper.Map<AnswerDto, Answer>(answerDto);
            answer.UserId = UserId;
            answer.DateTime = DateTime.UtcNow;
            answer.SeriesNumber = SeriesNumber;
            try
            {
                //todo
                //zrobić w TestRepository metody do wyciągania z TestTime Id Testu. To można zrobić za pomoc selecta. Wygooglaj albo wyciągnij po prostu cały TestTime
                var testTime = await UnitOfWork.Context.TestTimes.FirstOrDefaultAsync(p => p.Id == TestTimeId);
                Test test = await UnitOfWork.TestRepository.GetTestByTestTimeId(TestTimeId);
                answer.TestId = test.Id;

                //najpierw sprawdzić czy jest Secret w bazie, jak nie ma to wypierdolić błąd że już raz usunął
                var valid = await UnitOfWork.Context.Secrets.SingleOrDefaultAsync(p => p.Id == SecretId);
                if (valid != null)
                {
                    await UnitOfWork.SecretRepository.DeleteSecret(SecretId);
                }
                else
                {
                    return BadRequest("Answer already submited");
                }
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
            QuestionsForUserViewModel questions = new QuestionsForUserViewModel();
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

    }
}
