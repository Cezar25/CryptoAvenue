using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Commands
{
    public class CreateWallet : IRequest<Wallet>
    {
        public Guid CoinId { get; set; }
        public Coin Coin { get; set; }
        public Guid UserId { get; set; }
        public User WalletOwner { get; set; }
        public double CoinAmount { get; set; }
    }
}
