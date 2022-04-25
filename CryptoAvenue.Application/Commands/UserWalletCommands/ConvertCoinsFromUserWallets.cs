using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Commands.UserWalletCommands
{
    public class ConvertCoinsFromUserWallets : IRequest
    {
        public Guid UserId { get; set; }
        public Guid WalletId { get; set; }
        public Guid BoughtCoinID { get; set; }
        public double AmountOfSoldCoin { get; set; }
    }
}
