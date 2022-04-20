
using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.BLL
{
    public class DepositBusinessLogic
    {
        public static void AddCoin(User user, string coinAbreviation, double amount)
        {
            var db = new CryptoAvenueContext();

            if (db.Wallets.Where(x => x.UserID == user.UserID).Any(x => x.CoinType.Abreviation == coinAbreviation))  //Check if there is a wallet coitaining the inserted coin type
            {
                db.Wallets.Where(x => x.UserID == user.UserID).FirstOrDefault(x => x.CoinType.Abreviation == coinAbreviation).CoinAmount += amount;
            }
            else
            {
                if (db.Coins.Any(x => x.Abreviation == coinAbreviation))
                {
                    db.Add(new Wallet() { CoinID = db.Coins.FirstOrDefault(x => x.Abreviation == coinAbreviation).CoinID, UserID = user.UserID, CoinAmount = amount });
                }
            }
            db.SaveChanges();
        }
    }
}
