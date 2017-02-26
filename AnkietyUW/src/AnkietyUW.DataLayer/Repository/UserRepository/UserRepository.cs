using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.DbContext;
using AnkietyUW.DataLayer.Entities;
using AnkietyUW.DataLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace AnkietyUW.DataLayer.Repository.UserRepository
{
    public class UserRepository : Repository.Repository, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User> AddUser(User user)
        {
            user.Id = Guid.NewGuid();
            user.EmailAddress = null;
            user.Active = false;
            Context.Users.Add(user);
            return user;
        }

        public async Task<User> AddUserByKey(string key, Guid testId)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Key = key.ToUpper(),
                EmailAddress = null,
                Active = false,
                Sex = Sex.Man,
                TestId = testId
            };
            Context.Users.Add(user);
            return user;
        }

        public Task<User> EditUserToTest(User user)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> GetUsersInTest(Guid testId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByGuid(Guid guid)
        {
            //var user = Context.Users.Include(t => t.Test).FirstOrDefault(usr => usr.Id == guid);
            User user = Context.Users.FirstOrDefault(usr => usr.Id == guid);
            return user;
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

            if(user == null)
                return null;
            
            if (!string.IsNullOrEmpty(user.EmailAddress))
                return null;

            user.EmailAddress = emailAddress;
            user.Active = true;
            Context.Entry(user).State = EntityState.Modified;
            
            return user;
        }
    }
}

