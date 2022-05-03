
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Commands.UserWalletCommands
{
    public class DeductFromWalletCoinAmount : IRequest<Wallet>
    {
        public Guid WalletId { get; set; }
        public double DeductedAmount { get; set; }
    }
}
