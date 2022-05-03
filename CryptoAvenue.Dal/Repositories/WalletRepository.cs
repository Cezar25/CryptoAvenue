
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Wallet GetWalletByIdIncluded(Guid id)
        {
            return context.Wallets.Include(x => x.CoinType).Include(x => x.WalletOwner).SingleOrDefault(x => x.Id == id);
        }

        public Wallet GetWalletByIncluded(Expression<Func<Wallet, bool>> predicate)
        {
            return context.Wallets.Include(x => x.CoinType).Include(x => x.WalletOwner).SingleOrDefault(predicate);
        }

        public IEnumerable<Wallet> GetWalletsByCoinID(Guid coinID, bool includeAll = false)
        {
            var query = context.Wallets.Where(x => x.CoinID == coinID);
            if (includeAll)
            {
                query = query.Include(x => x.CoinType).Include(x => x.WalletOwner);
            }

            return query.ToList();
        }

        public IEnumerable<Wallet> GetWalletsByUserID(Guid userID, bool includeAll = false)
        {
            var query = context.Wallets.Where(x => x.UserID == userID);
            if (includeAll)
            {
                query = query.Include(x => x.CoinType).Include(x => x.WalletOwner);
            }
            return query.ToList();
        }
    }
}
