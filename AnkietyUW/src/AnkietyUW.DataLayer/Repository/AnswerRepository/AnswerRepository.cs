using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.DbContext;
using AnkietyUW.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnkietyUW.DataLayer.Repository.AnswerRepository
{
    public class AnswerRepository : Repository.Repository, IAnswerRepository
    {
        public AnswerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<ICollection<Answer>> GetAnswersForUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Answer>> GetAnswerForTest(Guid testId)
        {
            return await Context.Answers.Select(p => p).Where(p => p.TestId == testId).ToListAsync();
            //throw new NotImplementedException();
        }

        public Task<Answer> SaveAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
