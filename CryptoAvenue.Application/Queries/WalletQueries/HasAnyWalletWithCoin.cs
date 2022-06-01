using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Queries.WalletQueries
{
    public class HasAnyWalletWithCoin : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid CoinId { get; set; }

    }
}
