using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.Entities;

namespace AnkietyUW.DataLayer.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<User> AddUserToTest(User user, Guid testId);
        Task<User> EditUserToTest(User user);
        Task<ICollection<User>> GetUsersInTest(Guid testId);
        Task<bool> DeactivateUser(Guid userId);
        Task<bool> ActivateUser(Guid userId);
        Task<ICollection<User>> DeleteEmailsForUsersInTest();
        Task<User> AddEmailToUserWithKey(string key, string emailAddress);
    }
}
