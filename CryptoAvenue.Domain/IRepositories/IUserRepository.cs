﻿using CryptoAvenue.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Domain.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserByEmail(string email);
    }
}
