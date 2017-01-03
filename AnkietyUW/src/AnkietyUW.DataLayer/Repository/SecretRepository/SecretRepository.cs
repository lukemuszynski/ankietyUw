using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.DbContext;
using AnkietyUW.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnkietyUW.DataLayer.Repository.SecretRepository
{
    public class SecretRepository : Repository.Repository, ISecretRepository
    {
        public SecretRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<bool> DeleteSecret(Guid secretId)
        {
            
            throw new NotImplementedException();
        }

        public Task<Secret> CreateSecret(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
