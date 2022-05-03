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

        public ConvertCoinsFromUserWalletsHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(ConvertCoinsFromUserWallets request, CancellationToken cancellationToken)
        {
            var soldCoinWallet = repository.GetWalletByIdIncluded(request.WalletId);

            if (request.AmountOfSoldCoin > soldCoinWallet.CoinAmount)
            {
                return Unit.Value;
            }
            else
            {
                double amountOfCoinSoldInEUR = request.AmountOfSoldCoin * soldCoinWallet.CoinType.ValueInEUR;

                if (repository.Any(x => x.UserID == request.UserId && x.CoinID == request.BoughtCoinID))
                {
                    var receivedCoinWallet = repository.GetWalletByIncluded(x => x.UserID == request.UserId && x.CoinID == request.BoughtCoinID);

                    double amountOfCoinBought = amountOfCoinSoldInEUR / receivedCoinWallet.CoinType.ValueInEUR;
                    receivedCoinWallet.CoinAmount += amountOfCoinBought;

                    repository.Update(receivedCoinWallet);
                }
                else
                {
                     double amountOfCoinBought = amountOfCoinSoldInEUR / repository.GetWalletByIncluded(x => x.CoinID == request.BoughtCoinID).CoinType.ValueInEUR;
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
