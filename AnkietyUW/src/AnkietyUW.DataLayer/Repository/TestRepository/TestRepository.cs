using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.Entities;

namespace AnkietyUW.DataLayer.Repository.TestRepository
{
    public class TestRepository : ITestRepository
    {
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
