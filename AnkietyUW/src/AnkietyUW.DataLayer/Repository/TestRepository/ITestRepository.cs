using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.Entities;

namespace AnkietyUW.DataLayer.Repository
{
    public interface ITestRepository
    {
        Task<Test> AddTest(Test test);
        Task<Test> EditTest(Test test);
        Task<Test> GetTest(Guid id);
        Task<ICollection<Test>> GetAllTests();
    }
}
