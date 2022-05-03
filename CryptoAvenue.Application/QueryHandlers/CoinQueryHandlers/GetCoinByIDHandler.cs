using CryptoAvenue.Application.Queries.CoinQueries;
using CryptoAvenue.Dal;
using CryptoAvenue.Domain.IRepositories;
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
        private readonly ICoinRepository repository;

        public GetCoinByIDHandler(ICoinRepository repository)
        {
            this.repository = repository;
        }

        public Task<Coin> Handle(GetCoinByID request, CancellationToken cancellationToken)
        {
            var coin = repository.GetEntityByID(request.CoinId);
            return Task.FromResult(coin);
        }
    }
}
