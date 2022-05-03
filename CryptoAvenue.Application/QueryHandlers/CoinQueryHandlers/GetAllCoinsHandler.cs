
using CryptoAvenue.Application.Queries;
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
    public class GetAllCoinsHandler : IRequestHandler<GetAllCoins, List<Coin>>
    {
        private readonly ICoinRepository repository;

        public GetAllCoinsHandler(ICoinRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Coin>> Handle(GetAllCoins request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.FindAll().ToList());
        }
    }
}
