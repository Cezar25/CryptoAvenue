
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
