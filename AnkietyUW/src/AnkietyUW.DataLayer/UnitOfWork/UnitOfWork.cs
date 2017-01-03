using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.DbContext;
using AnkietyUW.DataLayer.Repository;
using AnkietyUW.DataLayer.Repository.AnswerRepository;
using AnkietyUW.DataLayer.Repository.SecretRepository;
using AnkietyUW.DataLayer.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace AnkietyUW.DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext context,IAnswerRepository answerRepository, ITestRepository testRepository, IUserRepository userRepository, ISecretRepository secretRepository)
        {
            Context = context;
            AnswerRepository = answerRepository;
            TestRepository = testRepository;
            UserRepository = userRepository;
            SecretRepository = secretRepository;
        }

        public IAnswerRepository AnswerRepository { get; set; }
        public ITestRepository TestRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public ISecretRepository SecretRepository { get; set; }

        public ApplicationDbContext Context { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
