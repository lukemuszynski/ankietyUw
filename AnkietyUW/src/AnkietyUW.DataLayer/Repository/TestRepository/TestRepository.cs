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

        public Task<Test> AddTest(Test test)
        {
            throw new NotImplementedException();
        }

        public Task<Test> EditTest(Test test)
        {
            throw new NotImplementedException();
        }

        public Task<Test> GetTest(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Test>> GetAllTests()
        {
            throw new NotImplementedException();
        }
    }
}
