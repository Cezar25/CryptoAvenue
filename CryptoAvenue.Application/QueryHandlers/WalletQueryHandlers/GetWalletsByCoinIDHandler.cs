using CryptoAvenue.Application.Queries.WalletQueries;
using CryptoAvenue.Dal;
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
    public class GetWalletsByCoinIDHandler : IRequestHandler<GetWalletsByCoinID, List<Wallet>>
    {
        private readonly IWalletRepository repository;

        public GetWalletsByCoinIDHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Wallet>> Handle(GetWalletsByCoinID request, CancellationToken cancellationToken)
        {
            var wallets = repository.FindAll(x => x.CoinID == request.CoinId).ToList();
            return Task.FromResult(wallets);
        }
    }
}
