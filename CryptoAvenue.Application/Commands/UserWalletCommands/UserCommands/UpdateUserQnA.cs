using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Commands.UserCommands
{
    public class UpdateUserQnA : IRequest<User>
    {
        public Guid UserId { get; set; }
        public string UserSecurityQuestion { get; set; }
        public string UserSecurityAnswer { get; set; }
    }
}
