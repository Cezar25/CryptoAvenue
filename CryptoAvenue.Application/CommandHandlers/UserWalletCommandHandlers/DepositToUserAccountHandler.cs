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
    public class DepositToUserAccountHandler : IRequestHandler<DepositToUserAccount>
    {
        private readonly IWalletRepository walletRepository;
        private readonly ICoinRepository coinRepository;

        public DepositToUserAccountHandler(IWalletRepository walletRepository, ICoinRepository coinRepository)
        {
            this.walletRepository = walletRepository;
            this.coinRepository = coinRepository;
        }

        public Task<Unit> Handle(DepositToUserAccount request, CancellationToken cancellationToken)
        {           
            var coin = coinRepository.GetAll().FirstOrDefault(x => x.Id == request.CoinId);
            if(coin == null || coin.Abreviation != "EUR" || coin.Abreviation != "USD")
                return null;
            else
            {
                if (walletRepository.GetAll().Any(x => x.CoinID == request.CoinId && x.UserID == request.UserId))
                {
                    var wallet = walletRepository.GetAll().FirstOrDefault(x => x.CoinID == request.CoinId && x.UserID == request.UserId);
                    wallet.CoinAmount += request.Amount;

                    walletRepository.Update(wallet);
                    walletRepository.SaveChanges();
                }
                else
                {
                    walletRepository.Insert(new Wallet()
                    {
                        CoinID = request.CoinId,
                        UserID = request.UserId,
                        CoinAmount = request.Amount
                    });
                    walletRepository.SaveChanges();
                };
                return (Task<Unit>)Task.CompletedTask;
            }          
            
        }
    }
}
