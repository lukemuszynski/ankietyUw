using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.Entities;

namespace AnkietyUW.DataLayer.Repository.AnswerRepository
{
    public interface IAnswerRepository
    {
        Task<ICollection<Answer>> GetAnswersForUser(Guid userId);
        Task<ICollection<Answer>> GetAnswerForTest(Guid testId);
        Task<Answer> SaveAnswer(Answer answer);
    }
}