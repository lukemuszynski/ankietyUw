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

        public async Task<bool> FindAndDeleteSecret(Guid secretId)
        {
            var valid = await Context.Secrets.SingleOrDefaultAsync(p => p.Id == secretId);
            if(valid != null)
            { Context.Secrets.Remove(valid);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSecret(Guid secretId)
        {

            Context.Secrets.Remove(new Secret() {Id = secretId});
            return true;
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

        public async Task<Secret> FindSecret(Guid userId, int seriesNumber)
        {
            return await Context.Secrets.FirstOrDefaultAsync(x => x.UserId == userId && x.SeriesNumber == seriesNumber);
        }
    }
}
