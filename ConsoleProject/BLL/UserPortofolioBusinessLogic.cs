using ConsoleProject.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.BLL
{
    public class UserPortofolioBusinessLogic
    {
        public static double GetTotalPortofolioValueInEUR(User user)
        {
            var db = new CryptoAvenueContext();

            double total = 0;
            foreach (var wallet in db.Wallets.Where(x => x.UserID == user.UserID).Include(x => x.CoinType))
            {
                total += wallet.CoinType.ValueInEUR * wallet.CoinAmount;
            }
            return total;
        }
        public static double GetTotalPortofolioValueInUSD(User user)
        {
            var db = new CryptoAvenueContext();

            double total = 0;
            foreach (var wallet in db.Wallets.Where(x => x.UserID == user.UserID).Include(x => x.CoinType))
            {
                total += wallet.CoinType.ValueInUSD * wallet.CoinAmount;
            }
            return total;
        }
        public static double GetTotalPortofolioValueInBTC(User user)
        {
            var db = new CryptoAvenueContext();

            double total = 0;
            foreach (var wallet in db.Wallets.Where(x => x.UserID == user.UserID).Include(x => x.CoinType))
            {
                total += wallet.CoinType.ValueInBTC * wallet.CoinAmount;
            }
            return total;
        }
        public static void DisplayPortofolio(User user)
        {
            var db = new CryptoAvenueContext();

            Console.WriteLine();
            foreach (var wallet in db.Wallets.Where(x => x.UserID == user.UserID).Include(x => x.CoinType))
            {
                Console.WriteLine($"Coin:  {wallet.CoinType.Abreviation} ({wallet.CoinType.Name})       amount:    {Math.Round(wallet.CoinAmount, 6)}");
            }
            Console.WriteLine();
        }

        public static void DisplayHiddenPortofolio(User user)
        {
            var db = new CryptoAvenueContext();

            Console.WriteLine();
            foreach (var wallet in db.Wallets.Where(x => x.UserID == user.UserID).Include(x => x.CoinType))
            {
                Console.WriteLine($"Coin:  {wallet.CoinType.Abreviation} ({wallet.CoinType.Name})       amount:    ---");
            }
            Console.WriteLine();
        }
        public static Dictionary<Coin, double> GetCoinPercentage(User user)
        {
            var db = new CryptoAvenueContext();

            Dictionary<Coin, double> percentageCoin = new Dictionary<Coin, Double>();

            double portofolioValueInEUR = 0;

            foreach (var wallet in db.Wallets.Where(x => x.UserID == user.UserID).Include(x => x.CoinType))
            {
                if (wallet.CoinAmount > 0)
                {
                    portofolioValueInEUR += (wallet.CoinAmount * wallet.CoinType.ValueInEUR);
                }
            }

            foreach (var wallet in db.Wallets.Where(x => x.UserID == user.UserID).Include(x => x.CoinType))
            {
                if (wallet.CoinAmount > 0)
                {
                    percentageCoin.Add(wallet.CoinType, (wallet.CoinAmount * wallet.CoinType.ValueInEUR * 100) / portofolioValueInEUR);
                }
            }

            return percentageCoin;
        }
        public static void DisplayCoinPercentage(User user)
        {
            Console.WriteLine();
            Dictionary<Coin, double> percentageCoin = GetCoinPercentage(user);
            foreach (var item in percentageCoin)
            {
                Console.WriteLine($"Coin type: {item.Key.Abreviation}  percentage: {Math.Round(item.Value, 3)} %\n");
            }
        }

        public static void AddCopiedPortofolio(User buyingUser, User portofolioOwner, double amount)
        {
            var db = new CryptoAvenueContext();

            Dictionary<Coin, double> percentageCoin = GetCoinPercentage(portofolioOwner);

            foreach (var pair in percentageCoin)
            {
                if (db.Wallets.Where(x => x.UserID == buyingUser.UserID).Include(x => x.CoinType).Any(x => x.CoinType.Abreviation == pair.Key.Abreviation))
                {
                    double addedAmount = ((pair.Value / 100) * amount) / db.Wallets.Where(x => x.UserID == buyingUser.UserID).Include(x => x.CoinType).FirstOrDefault(x => x.CoinType.Abreviation == pair.Key.Abreviation).CoinType.ValueInEUR;
                    db.Wallets.Where(x => x.UserID == buyingUser.UserID).FirstOrDefault(x => x.CoinType.Abreviation == pair.Key.Abreviation).CoinAmount += addedAmount;
                }
                else
                {
                    double addedAmount = ((pair.Value / 100) * amount) / pair.Key.ValueInEUR;
                    db.Wallets.Add(new Wallet() { CoinID = pair.Key.CoinID, UserID = buyingUser.UserID, CoinAmount = addedAmount });
                }
            }

            db.SaveChanges();
        }
    }
}
