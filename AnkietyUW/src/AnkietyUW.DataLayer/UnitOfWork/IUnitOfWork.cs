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
    public interface IUnitOfWork
    {
        IAnswerRepository AnswerRepository { get; set; }
        ITestRepository TestRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        ISecretRepository SecretRepository { get; set; }
        ApplicationDbContext Context { get; set; }
        Task<int> SaveChangesAsync();
    }
}
