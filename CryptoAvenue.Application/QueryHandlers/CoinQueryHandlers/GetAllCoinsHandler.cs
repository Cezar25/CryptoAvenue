
using CryptoAvenue.Application.Queries;
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
    public class GetAllCoinsHandler : IRequestHandler<GetAllCoins, List<Coin>>
    {
        private readonly CryptoAvenueContext context;

        public GetAllCoinsHandler(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public async Task<List<Coin>> Handle(GetAllCoins request, CancellationToken cancellationToken)
        {
            return context.Coins.ToList();
        }
    }
}
