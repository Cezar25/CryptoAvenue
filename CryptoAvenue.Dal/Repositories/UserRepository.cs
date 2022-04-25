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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CryptoAvenueContext context) : base(context)
        {
        }

        public User GetUserByEmail(string email)
        {
            return context.Users.SingleOrDefault(x => x.Email == email);
        }
    }
}
