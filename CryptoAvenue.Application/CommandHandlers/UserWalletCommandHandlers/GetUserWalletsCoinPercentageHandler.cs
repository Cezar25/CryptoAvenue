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
    public class GetUserWalletsCoinPercentageHandler : IRequestHandler<GetUserWalletsCoinPercentage, Dictionary<Coin, double>>
    {
        private readonly IWalletRepository repository;

        public GetUserWalletsCoinPercentageHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public Task<Dictionary<Coin, double>> Handle(GetUserWalletsCoinPercentage request, CancellationToken cancellationToken)
        {
            Dictionary<Coin, double> percentageCoin = new Dictionary<Coin, double>();

            double portofolioValueInEUR = 0;

            foreach (var wallet in repository.FindAll(x => x.UserID == request.UserId))
            {
                if (wallet.CoinAmount > 0)
                {
                    portofolioValueInEUR += (wallet.CoinAmount * wallet.CoinType.ValueInEUR);
                }
            }

            foreach (var wallet in repository.FindAll(x => x.UserID == request.UserId))
            {
                if (wallet.CoinAmount > 0)
                {
                    percentageCoin.Add(wallet.CoinType, (wallet.CoinAmount * wallet.CoinType.ValueInEUR * 100) / portofolioValueInEUR);
                }
            }

            return Task.FromResult(percentageCoin);
        }
    }
}
