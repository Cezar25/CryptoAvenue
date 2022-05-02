
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Dal.Repositories
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(CryptoAvenueContext context) : base(context)
        {
        }

        public Dictionary<Coin, double> GetCoinPercentage(Guid userId)
        {
            Dictionary<Coin, double> coinPercentage = new Dictionary<Coin, Double>();

            double portofolioValueInEUR = 0;

            foreach (var wallet in context.Wallets.Where(x => x.UserID == userId))
            {
                if (wallet.CoinAmount > 0)
                {
                    portofolioValueInEUR += (wallet.CoinAmount * wallet.CoinType.ValueInEUR);
                }
            }

            foreach (var wallet in context.Wallets.Where(x => x.UserID == userId))
            {
                if (wallet.CoinAmount > 0)
                {
                    coinPercentage.Add(wallet.CoinType, (wallet.CoinAmount * wallet.CoinType.ValueInEUR * 100) / portofolioValueInEUR);
                }
            }

            return coinPercentage;
        }

        public IEnumerable<Wallet> GetWalletsByCoinID(Guid coinID)
        {
            return context.Wallets.Where(x => x.CoinID == coinID).ToList();
        }

        public IEnumerable<Wallet> GetWalletsByUserID(Guid userID)
        {
            return context.Wallets.Where(x => x.UserID == userID).ToList();
        }
    }
}
