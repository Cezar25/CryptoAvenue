using CryptoAvenue.Application.Queries.WalletQueries;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.QueryHandlers.WalletQueryHandlers
{
    public class GetWalletByCoinIdAndUserIdHandler : IRequestHandler<GetWalletByCoinIdAndUserId, Wallet>
    {
        private readonly IWalletRepository repository;

        public GetWalletByCoinIdAndUserIdHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public Task<Wallet> Handle(GetWalletByCoinIdAndUserId request, CancellationToken cancellationToken)
        {
            var wallet =  repository.GetEntityBy(x => x.CoinID == request.CoinId && x.UserID == request.UserId);

            return Task.FromResult(wallet);
        }
    }
}
