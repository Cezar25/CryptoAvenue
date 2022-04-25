using CryptoAvenue.Application.Commands;
using CryptoAvenue.Dal.Repositories;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.CommandHandlers
{
    public class CreateWalletHandler : IRequestHandler<CreateWallet, Wallet>
    {
        private readonly IWalletRepository repository;

        public CreateWalletHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public Task<Wallet> Handle(CreateWallet request, CancellationToken cancellationToken)
        {
            var wallet = new Wallet()
            {
                CoinID = request.CoinId,
                UserID = request.UserId,
                CoinAmount = request.CoinAmount
            };

            if(wallet == null) return null;

            repository.Insert(wallet);
            repository.SaveChanges();

            return Task.FromResult(wallet);
        }
    }
}
