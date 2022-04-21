using CryptoAvenue.Application.Queries.CoinQueries;
using CryptoAvenue.Dal;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.QueryHandlers.CoinQueryHandlers
{
    public class GetCoinByIDHandler : IRequestHandler<GetCoinByID, Coin>
    {
        private readonly CryptoAvenueContext context;

        public GetCoinByIDHandler(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public async Task<Coin> Handle(GetCoinByID request, CancellationToken cancellationToken)
        {
            var coin = context.Coins.SingleOrDefault(c => c.Id == request.CoinID);
            return coin;
        }
    }
}
