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
    public class CoinRepository : GenericRepository<Coin>, ICoinRepository
    {
        public CoinRepository(CryptoAvenueContext context) : base(context)
        {

        }

        public IEnumerable<Coin> GetAllCoinsByUserId(Guid userId)
        {
            var wallets = context.Wallets.Where(x => x.UserID == userId).Include(x => x.CoinType);

            var coins = new List<Coin>();

            foreach (var wallet in wallets)
            {
                coins.Add(wallet.CoinType);
            }

            return coins;
        }

        public Coin GetCoinByAbreviation(string abreviation)
        {
            return context.Coins.SingleOrDefault(x => x.Abreviation == abreviation);
        }
    }
}
