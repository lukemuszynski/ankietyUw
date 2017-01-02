using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.Entities;

namespace AnkietyUW.DataLayer.Repository.AnswerRepository
{
    public class AnswerRepository : IAnswerRepository
    {
        public Task<ICollection<Answer>> GetAnswersForUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Answer>> GetAnswerForTest(Guid testId)
        {
            throw new NotImplementedException();
        }

        public Task<Answer> SaveAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
