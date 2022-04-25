using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Commands.UserWalletCommands
{
    public class AddCopiedPortofolioToUser : IRequest
    {
        public Guid CopierId { get; set; }
        public Guid CopiedId { get; set; }
        public double Amount { get; set; }
    }
}
