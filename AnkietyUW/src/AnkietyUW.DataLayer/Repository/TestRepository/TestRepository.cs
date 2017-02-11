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
            test.Id = Guid.NewGuid().ToString();
            Context.Tests.Add(test);
            return test;
        }

        public Task<Test> EditTest(Test test)
        {
            throw new NotImplementedException();
        }

        //public async Task<Test> GetTest(Guid id)
        //{

        //    var test = await Context.Tests.Include(t => t.Users).Include(t => t.TestTimes).FirstOrDefaultAsync(t => t.Id == id);
        //    return test;
        //}

        public Task<ICollection<Test>> GetAllTests()
        {
            throw new NotImplementedException();
        }

        public async Task<Test> GetTest(string id)
        {
            var test = await Context.Tests.Include(t => t.Users).Include(t => t.TestTimes).FirstOrDefaultAsync(t => t.Id == id);
            return test;
        }
    }
}
