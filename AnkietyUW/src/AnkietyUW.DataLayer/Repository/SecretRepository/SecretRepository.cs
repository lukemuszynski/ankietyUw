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

        public async Task<Secret> CreateSecret(Guid userId, int seriesNumber)
        {
            var secret = new Secret();
            secret.Id = new Guid();
            secret.UserId = userId;
            secret.SeriesNumber = seriesNumber;
            Context.Secrets.Add(secret);
            return secret;
        }
    }
}
