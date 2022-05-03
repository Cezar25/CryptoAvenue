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
    public class DeductFromWalletCoinAmountHandler : IRequestHandler<DeductFromWalletCoinAmount, Wallet>
    {
        private readonly IWalletRepository repository;

        public DeductFromWalletCoinAmountHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public Task<Wallet> Handle(DeductFromWalletCoinAmount request, CancellationToken cancellationToken)
        {
            var updated = repository.GetEntityByID(request.WalletId);

            if (request.DeductedAmount > updated.CoinAmount)
                throw new Exception("Deducted amount greater than available amount!");

            updated.CoinAmount -= request.DeductedAmount;
            repository.Update(updated);
            repository.SaveChanges();

            return Task.FromResult(updated);
        }
    }
}
