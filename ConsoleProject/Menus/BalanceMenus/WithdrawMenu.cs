using ConsoleProject.BLL;
using ConsoleProject.Domain;
using ConsoleProject.Menus.UserInfoMenus;
using ConsoleProject.StrategyPatterm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.BalanceMenus
{
    public class WithdrawMenu
    {
        public static void WithdrawMoney(User user)
        {
            var db = new CryptoAvenueContext();

            Console.WriteLine("Please select the fiat currency you want to withdraw:");
            Console.WriteLine("Press 1 for EUR.");
            Console.WriteLine("Press 2 for USD.");
            Console.WriteLine("Press 0 for going back to the balance page.");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    {
                        BalanceMenu.Balance(user);
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Please enter the amount(double) of EUR you want to withdraw:");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        if (amount > db.Wallets.Where(x => x.UserID == user.UserID).FirstOrDefault(x => x.CoinType.Abreviation == "EUR").CoinAmount)
                        {
                            Console.WriteLine("Wrong input! Please try again!");
                            WithdrawMoney(user);
                        }

                        WithdrawBusinessLogic.RemoveCoin(user, "EUR", amount);
                        Console.WriteLine("Withdrawal was succesful!");

                        BalanceMenu.Balance(user);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Please enter the amount(double) of USD you want to withddraw:");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        if (amount > db.Wallets.Where(x => x.UserID == user.UserID).FirstOrDefault(x => x.CoinType.Abreviation == "USD").CoinAmount)
                        {
                            Console.WriteLine("Wrong input! Please try again!");
                            WithdrawMoney(user);
                        }

                        WithdrawBusinessLogic.RemoveCoin(user, "USD", amount);
                        Console.WriteLine("Withdrawal was succesful!");

                        BalanceMenu.Balance(user);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong option! Please try again!");
                        WithdrawMoney(user);
                        break;
                    }
            }
        }
    }
}
