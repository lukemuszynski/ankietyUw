﻿using System;
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
            //przeciez robisz to tam nizej
            //answer.TestId = TestTimeId;
            try
            {
                //todo
                //zrobić w TestRepository metody do wyciągania z TestTime Id Testu. To można zrobić za pomoc selecta. Wygooglaj albo wyciągnij po prostu cały TestTime
                var testTime = await UnitOfWork.Context.TestTimes.FirstOrDefaultAsync(p => p.Id == TestTimeId);
                answer.TestId = testTime.TestId;
                //To nie jest wgl potrzebne bo Usera nie musisz dopisywać do Dto, samo Id Wystarcza
                //answer.User = await UnitOfWork.Context.Users.FirstOrDefaultAsync(p => p.Id == UserId.ToString());

                //najpierw sprawdzić czy jest Secret w bazie, jak nie ma to wypierdolić błąd że już raz usunął
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
        
        public AnswersController(IUnitOfWork unitOfWork, IQuestionsProvider questionProvider) : base(unitOfWork)
        {
            QuestionProvider = questionProvider;
        }

        protected IQuestionsProvider QuestionProvider { get; set; }



    }
}
