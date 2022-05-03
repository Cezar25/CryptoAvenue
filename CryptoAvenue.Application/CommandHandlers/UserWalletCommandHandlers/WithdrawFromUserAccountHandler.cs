using CryptoAvenue.Application.Commands.UserWalletCommands;
using CryptoAvenue.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.CommandHandlers.UserWalletCommandHandlers
{
    public class WithdrawFromUserAccountHandler : IRequestHandler<WithdrawFromUserAccount>
    {
        private readonly IWalletRepository walletRepository;
        private readonly ICoinRepository coinRepository;
        public WithdrawFromUserAccountHandler(IWalletRepository walletRepository, ICoinRepository coinRepository)
        {
            this.walletRepository = walletRepository;
            this.coinRepository = coinRepository;
        }
        public Task<Unit> Handle(WithdrawFromUserAccount request, CancellationToken cancellationToken)
        {
            var coin = coinRepository.GetEntityBy(x => x.Id == request.CoinId);
            if (coin == null || coin.Abreviation != "EUR" || coin.Abreviation != "USD")
                return null;
            else
            {
                var wallet = walletRepository.GetEntityBy(x => x.CoinID == request.CoinId);

                if(wallet.CoinAmount >= request.Amount)
                    walletRepository.Delete(wallet);
                else
                {
                    wallet.CoinAmount -= request.Amount;
                    walletRepository.Update(wallet);
                } 
                walletRepository.SaveChanges();
            }
            return (Task<Unit>)Task.CompletedTask;
        }
    }
}
