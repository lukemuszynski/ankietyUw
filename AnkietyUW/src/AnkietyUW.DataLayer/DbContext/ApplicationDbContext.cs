using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
namespace AnkietyUW.DataLayer.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        { }
        
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TestTime> TestTimes { get; set; }
        public DbSet<Secret> Secrets { get; set; }

    }
}
