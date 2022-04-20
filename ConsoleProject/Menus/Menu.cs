using ConsoleProject.Domain;
using ConsoleProject.Menus.UserInfoMenus;
using ConsoleProject.StrategyPatterm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class Menu
    {
        public static void Start()
        {
            //Console.Clear();
            //while (true)
            //{
            Console.WriteLine();
            Console.WriteLine("WELCOME TO CRYPTO AVENUE! ...THE BEST CRYPTO TRADING APP!");
            Console.WriteLine("For logging in, press 1!");
            Console.WriteLine("For registering, press 2!");
            //Console.WriteLine("For adding the coin database, press 4!");
            Console.WriteLine("For exiting the program, press 0!");

            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 0:
                    {
                        Console.WriteLine("Exiting the program...");
                        return;
                        //break;
                    }
                case 1:
                    {
                        LoginMenu.LoggingIn();

                        break;
                    }
                case 2:
                    {
                        RegisterMenu.Register();
                        break;
                    }
                case 4:
                    {
                        var db = new CryptoAvenueContext();

                        db.Coins.Add(new Coin("Euro", "EUR", 1, 1.15, 0.000023));
                        db.Coins.Add(new Coin("US dollar", "USD", 0.85, 1, 0.000021));
                        db.Coins.Add(new Coin("Bitcoin", "BTC", 42000, 47400, 1));

                        db.Coins.Add(new Coin("Ethereum", "ETH", 3074, 3370, 0.071));
                        db.Coins.Add(new Coin("Cardano", "ADA", 1.13, 1.24, 0.000026));
                        db.Coins.Add(new Coin("Solana", "SOL", 100, 111, 0.0037));
                        db.Coins.Add(new Coin("Sandbox", "SAND", 3.13, 3.61, 0.00007));
                        db.Coins.Add(new Coin("Dogecoin", "DOGE", 0.14, 0.16, 0.0000032));
                        db.Coins.Add(new Coin("BinanceCoin", "BNB", 393.7, 427.6, 0.1));
                        db.Coins.Add(new Coin("Ripple", "XRP", 0.7, 0.77, 0.000018));

                        db.SaveChanges();

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid choice! Please try again!");
                        Start();
                        break;
                    }
            }
            //}
        }

    }
}
