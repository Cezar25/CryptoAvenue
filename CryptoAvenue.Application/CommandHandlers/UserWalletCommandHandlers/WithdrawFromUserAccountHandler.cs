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
    public class WithdrawFromUserAccountHandler : IRequestHandler<WithdrawFromUserAccount, Wallet>
    {
        private readonly IUserRepository userRepository;
        private readonly IWalletRepository walletRepository;

        public WithdrawFromUserAccountHandler(IUserRepository userRepository, IWalletRepository walletRepository)
        {
            this.userRepository = userRepository;
            this.walletRepository = walletRepository;
        }

        public Task<Wallet> Handle(WithdrawFromUserAccount request, CancellationToken cancellationToken)
        {
            var wallet = walletRepository.GetEntityBy(x => x.CoinID == request.CoinId && x.UserID == request.UserId);

            if (wallet.CoinAmount >= request.Amount)
            {
                wallet.CoinAmount -= request.Amount;

                if (wallet.CoinAmount == 0)
                {
                    walletRepository.Delete(wallet);
                    walletRepository.SaveChanges();
                }

                else
                {
                    walletRepository.Update(wallet);
                    walletRepository.SaveChanges();
                }

                return Task.FromResult(wallet);
            }
            else
            {
                return null;
            }
        }
    }
}
