using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.DbContext;
using AnkietyUW.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnkietyUW.DataLayer.Repository.UserRepository
{
    public class UserRepository : Repository.Repository, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<User> AddUserToTest(User user, Guid testId)
        {
            throw new NotImplementedException();
        }

        public Task<User> EditUserToTest(User user)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> GetUsersInTest(Guid testId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeactivateUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActivateUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> DeleteEmailsForUsersInTest()
        {
            throw new NotImplementedException();
        }

        public async Task<User> AddEmailToUserWithKey(string key, string emailAddress)
        {
            var user = await Context.Users.FirstOrDefaultAsync(u => u.Key == key);

            if (!string.IsNullOrEmpty(user?.EmailAddress))
                return null;

            user.EmailAddress = emailAddress;
            user.Active = true;
            Context.Entry(user).State = EntityState.Modified;
            
            return user;
        }
    }
}
