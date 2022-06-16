using CryptoAvenue.Application.Queries.WalletQueries;
using CryptoAvenue.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.QueryHandlers.WalletQueryHandlers
{
    public class GetWalletValueInEurHandler : IRequestHandler<GetWalletValueInEur, double>
    {
        private readonly IWalletRepository repository;
        private readonly ICoinRepository coinRepository;

        public GetWalletValueInEurHandler(IWalletRepository repository, ICoinRepository coinRepository)
        {
            this.repository = repository;
            this.coinRepository = coinRepository;
        }

        public Task<double> Handle(GetWalletValueInEur request, CancellationToken cancellationToken)
        {
            var wallet = repository.GetEntityByID(request.WalletId);
            var coin = coinRepository.GetEntityByID(wallet.CoinID);

            return Task.FromResult(wallet.CoinAmount * coin.ValueInEUR);
        }
    }
}
