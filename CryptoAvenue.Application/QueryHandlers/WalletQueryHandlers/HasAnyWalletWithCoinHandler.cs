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
    public class HasAnyWalletWithCoinHandler : IRequestHandler<HasAnyWalletWithCoin, bool>
    {
        private readonly IWalletRepository repository;

        public HasAnyWalletWithCoinHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public Task<bool> Handle(HasAnyWalletWithCoin request, CancellationToken cancellationToken)
        {
            if (repository.Any(x => x.CoinID == request.CoinId && x.UserID == request.UserId))
                return Task.FromResult(true);

            return Task.FromResult(false);
        }
    }
}
