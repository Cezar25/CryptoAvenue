using CryptoAvenue.Application.Commands.UserWalletCommands;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.CommandHandlers.UserWalletCommandHandlers
{
    public class UpdateWalletHandler : IRequestHandler<UpdateWallet, Wallet>
    {
        private readonly IWalletRepository repository;

        public UpdateWalletHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public Task<Wallet> Handle(UpdateWallet request, CancellationToken cancellationToken)
        {
            var updated = new Wallet();
            updated.Id = request.WalletId;
            updated.CoinID = request.CoinID;
            updated.UserID = request.UserID;
            updated.CoinAmount = request.CoinAmount;

            repository.Update(updated);
            repository.SaveChanges();

            return Task.FromResult(updated);
        }
    }
}
