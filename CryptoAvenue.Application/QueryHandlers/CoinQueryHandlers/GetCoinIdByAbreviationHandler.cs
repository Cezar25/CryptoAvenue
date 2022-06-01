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
    public class GetCoinIdByAbreviationHandler : IRequestHandler<GetCoinIdByAbreviation, Guid>
    {
        private readonly ICoinRepository repository;

        public GetCoinIdByAbreviationHandler(ICoinRepository repository)
        {
            this.repository = repository;
        }

        public Task<Guid> Handle(GetCoinIdByAbreviation request, CancellationToken cancellationToken)
        {
            //var foundCoinId = repository.GetEntityBy(x => x.Abreviation == request.CoinAbreviation).Id;

            Guid foundCoinId = Guid.Empty;

            try
            {
                foundCoinId = repository.GetEntityBy(x => x.Abreviation == request.CoinAbreviation).Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Coin ID not found!");
                return null;
            }

            return Task.FromResult(foundCoinId);
        }
    }
}
