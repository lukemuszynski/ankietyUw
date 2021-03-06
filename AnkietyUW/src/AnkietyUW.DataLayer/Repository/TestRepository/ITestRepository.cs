﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.Entities;

namespace AnkietyUW.DataLayer.Repository
{
    public interface ITestRepository
    {
        Task<Test> GetTestByTestTimeId(Guid id);
        Task<Test> AddTest(Test test);
        Task<Test> UpdateTest(Test test);
        Task<Test> GetSingleTest(Guid id);
        Task<ICollection<Test>> GetAllTests();
        void DeleteTest(Test test);
        Task<List<Test>> GetAllNotCompletedTestsWithTestTimesAndUsers();
        Task<TestTime> GetTestTimeWithTestByTestTimeId(Guid id);
    }
}
