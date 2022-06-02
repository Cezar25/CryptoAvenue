using CryptoAvenue.Application.Queries.CoinQueries;
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
    public class GetAllCoinsByUserIdHandler : IRequestHandler<GetAllCoinsByUserId, List<Coin>>
    {
        private readonly ICoinRepository coinRepository;

        public GetAllCoinsByUserIdHandler(ICoinRepository coinRepository)
        {
            this.coinRepository = coinRepository;
        }

        public Task<List<Coin>> Handle(GetAllCoinsByUserId request, CancellationToken cancellationToken)
        {
            return Task.FromResult(coinRepository.GetAllCoinsByUserId(request.UserId).ToList());
        }
    }
}
