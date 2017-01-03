using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AnkietyUW.DataLayer.Repository.Repository
{
    public class Repository
    {
        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }
        protected ApplicationDbContext Context { get; set; }
    }
}
