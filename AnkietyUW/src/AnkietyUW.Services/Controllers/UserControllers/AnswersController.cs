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

            try
            {
                Answer answer = Mapper.Map<AnswerDto, Answer>(answerDto);
                answer.UserId = UserId;
                answer.DateTime = DateTime.UtcNow;
                answer.SeriesNumber = SeriesNumber;


                var testTime = await UnitOfWork.TestRepository.GetTestTimeWithTestByTestTimeId(TestTimeId);

                if (testTime.DateTime != DateTime.UtcNow.Date)
                    return BadRequest("Token is outdated");

                answer.TestId = testTime.TestId;

                switch (SeriesNumber % 4)
                {
                    case 0:
                        if (DateTime.UtcNow > testTime.DateTime.AddSeconds(testTime.Test.FirstQuestionAddSeconds + testTime.Test.TimeToFillTestAddSeconds))
                            return BadRequest("Time to fill has passed");
                        break;
                    case 1:
                        if (DateTime.UtcNow > testTime.DateTime.AddSeconds(testTime.Test.SecondQuestionAddSeconds + testTime.Test.TimeToFillTestAddSeconds))
                            return BadRequest("Time to fill has passed");
                        break;
                    case 2:
                        if (DateTime.UtcNow > testTime.DateTime.AddSeconds(testTime.Test.ThirdQuestionAddSeconds + testTime.Test.TimeToFillTestAddSeconds))
                            return BadRequest("Time to fill has passed");
                        break;
                    case 3:
                        if (DateTime.UtcNow > testTime.DateTime.AddSeconds(testTime.Test.FourthQuestionAddSeconds + testTime.Test.TimeToFillTestAddSeconds))
                            return BadRequest("Time to fill has passed");
                        break;
                }

                //najpierw sprawdzić czy jest Secret w bazie, jak nie ma to wypierdolić błąd że już raz usunął

                if (!await UnitOfWork.SecretRepository.FindAndDeleteSecret(SecretId))
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
            try
            {
                questions.questions = QuestionProvider.QuestionsForSeriesNumber(SeriesNumber);
            }
            catch (Exception ex)
            {
                var k = new JsonResult(ex);
                k.StatusCode = 500;
                return k;
            }

            return Ok(questions);
        }

    }
}
