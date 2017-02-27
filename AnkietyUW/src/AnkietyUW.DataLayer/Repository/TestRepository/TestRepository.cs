using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.DbContext;
using AnkietyUW.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnkietyUW.DataLayer.Repository.TestRepository
{
    public class TestRepository : Repository.Repository, ITestRepository
    {
        public TestRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<Test> AddTest(Test test)
        {
            test.Id = Guid.NewGuid();
            Context.Tests.Add(test);
            return test;
        }

        public async Task<Test> UpdateTest(Test test)
        {

            Context.Tests.Update(test);
            
            return test;
        }

        public async Task<ICollection<Test>> GetAllTests()
        {
            return await Context.Tests.ToListAsync();
        }

        public async Task<Test> GetSingleTest(Guid id)
        {
            var test = await Context.Tests.Include(t => t.Users).Include(t => t.TestTimes).FirstOrDefaultAsync(t => t.Id == id);
            return test;
        }

        public void DeleteTest(Test test)
        {
            Context.Tests.Remove(test);
        }

        public async Task<List<Test>> GetAllNotCompletedTestsWithTestTimesAndUsers()
        {
            var tests = await Context.Tests.Include(t => t.Users).Include(t => t.TestTimes).Where(t => t.CompletedSeriesCounter < 60).ToListAsync();
            return tests;
        }

        public async Task<Test> GetTestByTestTimeId(Guid id)
        {

            var test = await Context.TestTimes.Include(t => t.Test).FirstOrDefaultAsync(tt => tt.Id == id);

            return test.Test;

            //var query = Context.Tests.ToArray();
            //foreach (var test in query)
            //{
            //    if (test.TestTimes.SingleOrDefault(p => p.Id == id) != null)
            //    {
            //        return test;
            //    }
            //}
            //return null;
        }

        public async Task<TestTime> GetTestTimeWithTestByTestTimeId(Guid id)
        {
            var test = await Context.TestTimes.Include(tt => tt.Test).FirstOrDefaultAsync(tt => tt.Id == id);

            return test;

        }
    }
}
