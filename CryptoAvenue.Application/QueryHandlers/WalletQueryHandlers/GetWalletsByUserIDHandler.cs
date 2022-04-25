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
    public class GetWalletsByUserIDHandler : IRequestHandler<GetWalletsByUserID, List<Wallet>>
    {
        private readonly IWalletRepository repository;

        public GetWalletsByUserIDHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Wallet>> Handle(GetWalletsByUserID request, CancellationToken cancellationToken)
        {
            var wallets = repository.GetAll().Where(x => x.UserID == request.UserId).ToList();
            return Task.FromResult(wallets);
        }
    }
}
