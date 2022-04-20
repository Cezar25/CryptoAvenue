using ConsoleProject.BLL;
using ConsoleProject.Domain;
using ConsoleProject.StrategyPatterm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.UserToUserTradeMenus
{
    public class SendTradeOfferMenu
    {
        public static void SendTradeOffer(User sender, User recipient)
        {
            var db = new CryptoAvenueContext();

            var context = new ShowBalanceContext();
            context.SetStrategy(new ShownBalanceStrategy());

            Console.WriteLine("Choose which coin you wish to buy from the user:");
            int boughtIndex = 0;

            foreach (var coin in db.Wallets.Where(x => x.UserID == recipient.UserID).Include(x => x.CoinType))
            {
                Console.WriteLine($"Press {boughtIndex} for {coin.CoinType.Abreviation}.");
                boughtIndex++;
            }

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 0 || choice > boughtIndex)
            {
                Console.WriteLine("Wrong choice! Please try again!");
                SendTradeOffer(sender, recipient);
            }
            else
            {
                Console.WriteLine($"Please type in the amount of {db.Wallets.Where(x => x.UserID == recipient.UserID).ToList()[choice].CoinType.Abreviation} you wish to buy from the user   (amount available: {db.Wallets.Where(x => x.UserID == recipient.UserID).ToList()[choice].CoinAmount})");
                Console.WriteLine($"Selected coin: {db.Wallets.Where(x => x.UserID == recipient.UserID).ToList()[choice].CoinType.Abreviation}");
                double boughtAmount = Convert.ToDouble(Console.ReadLine());

                if (boughtAmount < 0 || boughtAmount > db.Wallets.Where(x => x.UserID == recipient.UserID).ToList()[choice].CoinAmount)
                {
                    Console.WriteLine("Wrong choice! Please try again!");
                    SendTradeOffer(sender, recipient);
                }
                else
                {
                    Console.WriteLine("Please select the coin you wish to sell from your portofolio:");
                    int soldIndex = 0;
                    foreach (var coin in db.Wallets.Where(x => x.UserID == sender.UserID).Include(x => x.CoinType))
                    {

                        Console.WriteLine($"Press {soldIndex} for {coin.CoinType.Abreviation}.");
                        soldIndex++;

                    }

                    int choice2 = Convert.ToInt32(Console.ReadLine());

                    if (choice2 < 0 || choice2 > soldIndex)
                    {
                        Console.WriteLine("Wrong choice! Please try again!");
                        SendTradeOffer(sender, recipient);
                    }
                    else
                    {
                        Console.WriteLine($"Buying {boughtAmount} {db.Wallets.Where(x => x.UserID == recipient.UserID).ToList()[choice].CoinType.Abreviation} worth {AppTradeBusinessLogic.GetSoldCoinAmount(boughtAmount, db.Wallets.Where(x => x.UserID == recipient.UserID).ToList()[choice].CoinType.Abreviation, db.Wallets.Where(x => x.UserID == sender.UserID).ToList()[choice2].CoinType.Abreviation)} {db.Wallets.Where(x => x.UserID == sender.UserID).ToList()[choice2].CoinType.Abreviation} ");
                        AppTradeBusinessLogic.GetConversionRate(db.Wallets.Where(x => x.UserID == sender.UserID).ToList()[choice2].CoinType.Abreviation, db.Wallets.Where(x => x.UserID == recipient.UserID).ToList()[choice].CoinType.Abreviation);

                        db.Add(new TradeOffer
                        {
                            SenderID = sender.UserID,
                            RecipientID = recipient.UserID,
                            SentCoinID = db.Wallets.Where(x => x.UserID == sender.UserID).ToList()[choice2].CoinType.CoinID,
                            SentAmount = AppTradeBusinessLogic.GetSoldCoinAmount(boughtAmount, db.Wallets.Where(x => x.UserID == recipient.UserID).ToList()[choice].CoinType.Abreviation, db.Wallets.Where(x => x.UserID == sender.UserID).ToList()[choice2].CoinType.Abreviation),
                            ReceivedCoinID = db.Wallets.Where(x => x.UserID == recipient.UserID).ToList()[choice].CoinType.CoinID,
                            ReceivedAmount = boughtAmount
                        });
                        db.SaveChanges();

                        context.ShowBalance(sender);
                    }
                }
            }
        }
    }
}
