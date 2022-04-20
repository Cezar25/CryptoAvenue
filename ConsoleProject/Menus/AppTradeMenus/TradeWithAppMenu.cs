using ConsoleProject.BLL;

using ConsoleProject.Domain;
using ConsoleProject.Menus.UserInfoMenus;
using ConsoleProject.StrategyPatterm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.AppTradeMenus
{
    public class TradeWithAppMenu
    {
        public static void TradeWithApp(User user)
        {
            var db = new CryptoAvenueContext();

            Console.Clear();
            Console.WriteLine("Welcome to the App Trading page!");
            Console.WriteLine("Here you can exchange currencies from your portofolio directly with the app wallet INSTANTLY!");
            Console.WriteLine();
            Console.WriteLine("Please select the coin you want to SELL!");

            int index = 0;

            foreach (var wallet in db.Wallets.Where(x => x.UserID == user.UserID).Include(x => x.CoinType))
            {
                Console.WriteLine($"Press {index} for {wallet.CoinType.Abreviation}      (available amount: {wallet.CoinAmount})");
                index++;
            }

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 0 || choice > index)
            {
                Console.WriteLine("Wrong choice! Please try again!");
                TradeWithApp(user);
            }
            else
            {
                Console.WriteLine($"Please type in the amount of {db.Wallets.Where(x => x.UserID == user.UserID).ToList()[choice].CoinType.Abreviation} you wish to sell");
                double sellAmount = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("Please select the coin you with to BUY from the list:");

                int index2 = 0;

                if (db.Wallets.Where(x => x.UserID == user.UserID).ToList()[choice].CoinType.Abreviation == "EUR" || db.Wallets.Where(x => x.UserID == user.UserID).ToList()[choice].CoinType.Abreviation == "USD" || db.Wallets.Where(x => x.UserID == user.UserID).ToList()[choice].CoinType.Abreviation == "BTC")
                {
                    foreach (var coin in db.Coins)
                    {
                        Console.WriteLine($"Press {index2} for {coin.Abreviation}");
                        index2++;
                    }
                    int choice2 = Convert.ToInt32(Console.ReadLine());

                    if (choice2 < 0 || choice2 > index2)
                    {
                        Console.WriteLine("Wrong choice! Please try again!");
                        TradeWithApp(user);
                    }
                    else
                    {
                        ShowTradeOffer(user, db.Wallets.Where(x => x.UserID == user.UserID).ToList()[choice].CoinType.Abreviation, sellAmount, db.Coins.ToList()[choice2].Abreviation, AppTradeBusinessLogic.GetBoughtCoinAmount(sellAmount, db.Wallets.Where(x => x.UserID == user.UserID).ToList()[choice].CoinType.Abreviation, db.Coins.ToList()[choice2].Abreviation), choice, choice2);

                    }
                }
                else
                {
                    foreach (var coin in db.Coins)
                    {
                        if (coin.Abreviation != "EUR" || coin.Abreviation != "USD" || coin.Abreviation != "BTC")
                        {
                            Console.WriteLine($"Press {index2} for {coin.Abreviation}");
                            index2++;
                        }

                    }
                    int choice2 = Convert.ToInt32(Console.ReadLine());

                    if (choice2 < 0 || choice2 > index2)
                    {
                        Console.WriteLine("Wrong choice! Please try again!");
                        TradeWithApp(user);
                    }
                    else
                    {
                        ShowTradeOffer(user, db.Wallets.Where(x => x.UserID == user.UserID).ToList()[choice].CoinType.Abreviation, sellAmount, db.Coins.ToList()[choice2].Abreviation, AppTradeBusinessLogic.GetBoughtCoinAmount(sellAmount, db.Wallets.Where(x => x.UserID == user.UserID).ToList()[choice].CoinType.Abreviation, db.Coins.ToList()[choice2].Abreviation), choice, choice2);
                    }
                }

            }
            db.SaveChanges();
        }

        public static void ShowTradeOffer(User user, string soldCoinAbreviation, double soldCoinAmount, string boughtCoinAbreviation, double boughtCoinAmount, int choice1, int choice2)
        {
            var db = new CryptoAvenueContext();

            Console.WriteLine();
            Console.WriteLine("Your trade offer is: ");
            Console.WriteLine($"{soldCoinAmount }  {soldCoinAbreviation} for {Math.Round(boughtCoinAmount, 6)}  {boughtCoinAbreviation}");
            AppTradeBusinessLogic.GetConversionRate(soldCoinAbreviation, boughtCoinAbreviation);

            Console.WriteLine();
            Console.WriteLine("Press 1 to ACCEPT the trade offer.");
            Console.WriteLine("Press 2 to DENY the trade offer.");
            Console.WriteLine("Press 0 to go back to the BALANCE page.");

            //int duration = 15;
            //for(int i= duration; i >= 0; i--)
            //{
            //    Console.WriteLine($"\rYou have {i} seconds to ACCEPT the trade!");               
            //    System.Threading.Thread.Sleep(1000);
            //}

            var context = new ShowBalanceContext();
            context.SetStrategy(new ShownBalanceStrategy());

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    {
                        Console.WriteLine("Returning to BAlANCE page...");

                        context.ShowBalance(user);
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Trade accepted! Proceding with the trade...");
                        AppTradeBusinessLogic.ConvertCoinToCoin(user, db.Wallets.Where(x => x.UserID == user.UserID).Include(x => x.CoinType).ToList()[choice1], soldCoinAmount, boughtCoinAbreviation);

                        context.ShowBalance(user);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Trade cancelled! Returning to BALANCE page....");
                        context.ShowBalance(user);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong choice! Please try again!");
                        ShowTradeOffer(user, soldCoinAbreviation, soldCoinAmount, boughtCoinAbreviation, boughtCoinAmount, choice1, choice2);
                        break;
                    }
            }
        }


    }
}
