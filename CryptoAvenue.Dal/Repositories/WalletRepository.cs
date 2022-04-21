using CryptoAvenue.Dal.IRepositories;
using CryptoAvenue.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Dal.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly CryptoAvenueContext context;

        public WalletRepository(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public void DeleteWallet(Guid walletID)
        {
            Wallet wallet = context.Wallets.Find(walletID);
            context.Wallets.Remove(wallet);
        }

        public Wallet GetWalletByID(Guid walletID)
        {
            return context.Wallets.Find(walletID);
        }

        public IEnumerable<Wallet> GetWallets()
        {
            return context.Wallets.ToList();
        }

        public IEnumerable<Wallet> GetWalletsByCoinID(Guid coinID)
        {
            return context.Wallets.Where(x => x.CoinID == coinID).ToList();
        }

        public IEnumerable<Wallet> GetWalletsByUserID(Guid userID)
        {
            return context.Wallets.Where(x => x.UserID == userID).ToList();
        }

        public void InsertWallet(Wallet wallet)
        {
            context.Add(wallet);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateWallet(Wallet wallet)
        {
            context.Entry(wallet).State = EntityState.Modified;
        }
    }
}
