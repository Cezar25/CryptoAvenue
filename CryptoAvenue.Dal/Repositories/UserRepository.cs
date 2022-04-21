using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CryptoAvenueContext context;

        public UserRepository(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public void DeleteUser(Guid userID)
        {
            User user = context.Users.Find(userID);
            context.Users.Remove(user);
        }

        public User GetUserByEmail(string email)
        {
            return context.Users.Find(email);
        }

        public User GetUserByID(Guid userID)
        {
            return context.Users.Find(userID);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public void InsertUser(User user)
        {
            context.Add(user);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
    }
}
