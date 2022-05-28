using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Commands.UserWalletCommands
{
    public class DepositToUserAccount : IRequest<Wallet>
    {
        public Guid UserId { get; set; }
        public Guid CoinId { get; set; }
        public double Amount { get; set; }
    }
}
