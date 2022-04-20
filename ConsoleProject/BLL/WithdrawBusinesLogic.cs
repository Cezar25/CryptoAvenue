using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.BLL
{
    public class WithdrawBusinessLogic
    {
        public static void RemoveCoin(User user, string coinAbreviation, double amount)
        {
            var db = new CryptoAvenueContext();

            if (db.Wallets.Where(x => x.UserID == user.UserID).Any(x => x.CoinType.Abreviation == coinAbreviation))  //Check if there is a wallet coitaining the inserted coin type
            {
                if (db.Wallets.Where(x => x.UserID == user.UserID).FirstOrDefault(x => x.CoinType.Abreviation == coinAbreviation).CoinAmount >= amount)
                {
                    db.Wallets.Where(x => x.UserID == user.UserID).FirstOrDefault(x => x.CoinType.Abreviation == coinAbreviation).CoinAmount -= amount;
                }
                else
                {
                    Console.WriteLine("Coin could not be removed!");
                }
            }
            else
            {
                Console.WriteLine("Coin could not be removed!");
            }

            db.SaveChanges();
        }
    }
}
