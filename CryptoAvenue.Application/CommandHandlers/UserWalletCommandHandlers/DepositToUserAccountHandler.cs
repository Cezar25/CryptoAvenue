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
    public class DepositToUserAccountHandler : IRequestHandler<DepositToUserAccount, Wallet>
    {
        private readonly IUserRepository userRepository;
        private readonly IWalletRepository walletRepository;

        public DepositToUserAccountHandler(IUserRepository userRepository, IWalletRepository walletRepository)
        {
            this.userRepository = userRepository;
            this.walletRepository = walletRepository;
        }

        public Task<Wallet> Handle(DepositToUserAccount request, CancellationToken cancellationToken)
        {
            if(walletRepository.Any(x => x.CoinID == request.CoinId && x.UserID == request.UserId))
            {
                var wallet = walletRepository.GetEntityBy(x => x.CoinID == request.CoinId && x.UserID == request.UserId);

                wallet.CoinAmount += request.Amount;

                walletRepository.Update(wallet);
                walletRepository.SaveChanges();

                return Task.FromResult(wallet);
            }
            else
            {
                var newWallet = new Wallet
                {
                    UserID = request.UserId,
                    CoinID = request.CoinId,
                    CoinAmount = request.Amount
                };

                walletRepository.Insert(newWallet);
                walletRepository.SaveChanges();

                return Task.FromResult(newWallet);
            }
        }
    }
}
