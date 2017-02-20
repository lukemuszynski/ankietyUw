using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.Entities;

namespace AnkietyUW.DataLayer.Repository.SecretRepository
{
    public interface ISecretRepository
    {
        Task<bool> DeleteSecret(Guid secretId);
        Task<Secret> CreateSecret(Guid userId, int seriesNumber);
    }
}
