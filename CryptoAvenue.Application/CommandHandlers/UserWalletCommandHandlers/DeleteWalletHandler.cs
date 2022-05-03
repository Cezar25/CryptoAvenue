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
    public class DeleteWalletHandler : IRequestHandler<DeleteWallet, Wallet>
    {
        private readonly IWalletRepository repository;

        public DeleteWalletHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public Task<Wallet> Handle(DeleteWallet request, CancellationToken cancellationToken)
        {
            var wallet = repository.GetEntityBy(x => x.Id == request.WalletId);

            if (wallet == null) return null;

            repository.Delete(wallet);
            repository.SaveChanges();

            return Task.FromResult(wallet);
        }
    }
}
