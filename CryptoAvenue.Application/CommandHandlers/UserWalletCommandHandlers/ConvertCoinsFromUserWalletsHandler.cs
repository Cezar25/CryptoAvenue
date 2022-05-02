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
    public class ConvertCoinsFromUserWalletsHandler : IRequestHandler<ConvertCoinsFromUserWallets>
    {
        private readonly IWalletRepository repository;
        public async Task<Unit> Handle(ConvertCoinsFromUserWallets request, CancellationToken cancellationToken)
        {
            var soldCoinWallet = repository.GetEntityByID(request.WalletId);

            if (request.AmountOfSoldCoin > soldCoinWallet.CoinAmount)
            {
                return Unit.Value;
            }
            else
            {
                double amountOfCoinSoldInEUR = request.AmountOfSoldCoin * soldCoinWallet.CoinType.ValueInEUR;

                if (repository.GetAll().Any(x => x.UserID == request.UserId && x.CoinID == request.BoughtCoinID))
                {
                    var receivedCoinWallet = repository.GetAll().FirstOrDefault(x => x.UserID == request.UserId && x.CoinID == request.BoughtCoinID);

                    double amountOfCoinBought = amountOfCoinSoldInEUR / receivedCoinWallet.CoinType.ValueInEUR;
                    receivedCoinWallet.CoinAmount += amountOfCoinBought;

                    repository.Update(receivedCoinWallet);
                }
                else
                {
                     double amountOfCoinBought = amountOfCoinSoldInEUR / repository.GetAll().FirstOrDefault(x => x.CoinID == request.BoughtCoinID).CoinType.ValueInEUR;
                     repository.Insert(new Wallet() { CoinID = request.BoughtCoinID, UserID = request.UserId, CoinAmount = amountOfCoinBought });
                }

                soldCoinWallet.CoinAmount -= request.AmountOfSoldCoin;
                repository.Update(soldCoinWallet);

                repository.SaveChanges();
            }

            return Unit.Value;
        }
    }
}
