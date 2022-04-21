using CryptoAvenue.Application.Queries.WalletQueries;
using CryptoAvenue.Dal;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.QueryHandlers.WalletQueryHandlers
{
    public class GetWalletsByCoinIDHandler : IRequestHandler<GetWalletsByCoinID, List<Wallet>>
    {
        private readonly CryptoAvenueContext context;

        public GetWalletsByCoinIDHandler(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public async Task<List<Wallet>> Handle(GetWalletsByCoinID request, CancellationToken cancellationToken)
        {
            var wallets = context.Wallets.Where(x => x.CoinID == request.CoinID).ToList();
            return wallets;
        }
    }
}
