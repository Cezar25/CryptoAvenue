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
    public class AddToWalletCoinAmountHandler : IRequestHandler<AddToWalletCoinAmount, Wallet>
    {
        private readonly IWalletRepository repository;

        public AddToWalletCoinAmountHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public Task<Wallet> Handle(AddToWalletCoinAmount request, CancellationToken cancellationToken)
        {
            var updated = repository.GetEntityByID(request.WalletId);
            updated.CoinAmount += request.AddedAmount;
            repository.Update(updated);
            repository.SaveChanges();

            return Task.FromResult(updated);
        }
    }
}
