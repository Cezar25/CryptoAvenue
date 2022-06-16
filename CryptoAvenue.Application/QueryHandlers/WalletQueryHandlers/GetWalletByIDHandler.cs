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
    public class GetWalletByIDHandler : IRequestHandler<GetWalletByID, Wallet>
    {
        private readonly IWalletRepository repository;

        public GetWalletByIDHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public Task<Wallet> Handle(GetWalletByID request, CancellationToken cancellationToken)
        {
            var wallet = repository.GetWalletByIdIncluded(request.WalletId);
            return Task.FromResult(wallet);
        }
    }
}
