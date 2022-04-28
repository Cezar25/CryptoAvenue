﻿using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Commands
{
    public class CreateUser : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public bool PrivateProfile { get; set; }
    }
}
