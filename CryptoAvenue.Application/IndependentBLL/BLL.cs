using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.IndependentBLL
{
    public class BLL
    {
        private readonly ICoinRepository? coinRepository;
        private readonly IWalletRepository? walletRepository;
        private readonly IUserRepository? userRepository;
        private readonly ITradeOfferRepository? tradeOfferRepository;

        public BLL(IWalletRepository walletRepository)
        {
            this.walletRepository = walletRepository;
        }

        public BLL(ICoinRepository coinRepository)
        {
            this.coinRepository = coinRepository;
        }

        public Dictionary<Coin, double> GetCoinPercentage(User user)
        {
            Dictionary<Coin, double> coinPercentage = new Dictionary<Coin, Double>();

            double portofolioValueInEUR = 0;

            foreach (var wallet in walletRepository.GetAll().Where(x => x.UserID == user.Id))
            {
                if (wallet.CoinAmount > 0)
                {
                    portofolioValueInEUR += (wallet.CoinAmount * wallet.CoinType.ValueInEUR);
                }
            }

            foreach (var wallet in walletRepository.GetAll().Where(x => x.UserID == user.Id))
            {
                if (wallet.CoinAmount > 0)
                {
                    coinPercentage.Add(wallet.CoinType, (wallet.CoinAmount * wallet.CoinType.ValueInEUR * 100) / portofolioValueInEUR);
                }
            }

            return coinPercentage;
        }
        //public static void GetConversionRate(Guid soldCoinId, Guid boughtCoinId)
        //{
        //    if (coinRepository.GetAll().Any(x => x.Abreviation == soldCoinAbreviation) && db.Coins.Any(x => x.Abreviation == boughtCoinAbreviation))
        //    {
        //        double rate = db.Coins.Single(x => x.Abreviation == soldCoinAbreviation).ValueInEUR / db.Coins.Single(x => x.Abreviation == boughtCoinAbreviation).ValueInEUR;
        //        Console.WriteLine($"1 {soldCoinAbreviation}  =  {Math.Round(rate, 6)} {boughtCoinAbreviation}");
        //    }
        //}
    }
}
