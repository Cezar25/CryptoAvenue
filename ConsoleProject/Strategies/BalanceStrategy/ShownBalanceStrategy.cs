using ConsoleProject.BLL;
using ConsoleProject.Domain;
using ConsoleProject.Menus.AppTradeMenus;
using ConsoleProject.Menus.BalanceMenus;
using ConsoleProject.Menus.UserInfoMenus;
using ConsoleProject.Menus.UserToUserTradeMenus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.StrategyPatterm
{
    public class ShownBalanceStrategy : IShowBalanceStrategy
    {
        public void ShowBalance(User user)
        {
            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("BALANCE PAGE");

            var db = new CryptoAvenueContext();

            Console.WriteLine($"Welcome {user.Email}!");
            Console.WriteLine($"Your total balance amount is:    {Math.Round(UserPortofolioBusinessLogic.GetTotalPortofolioValueInEUR(user), 3)} EUR");
            AccountBusinessLogic.DisplayPrivacy(user);

            Console.WriteLine();
            Console.WriteLine("Below you have a list of all the coins in your portofolio");
            UserPortofolioBusinessLogic.DisplayPortofolio(user);

            Console.WriteLine("\nWhat do you wish to do now?");
            Console.WriteLine("Press 1 for depositing money.");
            Console.WriteLine("Press 2 for withdrawing money.");
            Console.WriteLine("Press 3 for editing your profile");
            Console.WriteLine("Press 4 to hide your balance amount.");
            Console.WriteLine("Press 5 to make your profile private/public");
            Console.WriteLine("Press 6 to trade with the app");
            Console.WriteLine("Press 7 to search for another user");
            Console.WriteLine("Press 8 view notifications");
            Console.WriteLine("Press 9 for logging out");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        GetCreditCardInfoMenu.GetCreditCardInfo(user);

                        break;
                    }
                case 2:
                    {
                        GetBankAccountInfoMenu.GetBankAccountInfo(user);

                        break;
                    }
                case 3:
                    {
                        EditProfileMenu.EditProfile(user);

                        break;
                    }
                case 4:
                    {
                        var context = new ShowBalanceContext();
                        context.SetStrategy(new HiddenBalanceStrategy());
                        context.ShowBalance(user);

                        break;
                    }
                case 5:
                    {
                        AccountBusinessLogic.ChangeProfileType(user);
                        ShowBalance(user);
                        break;
                    }
                case 6:
                    {
                        TradeWithAppMenu.TradeWithApp(user);
                        break;
                    }
                case 7:
                    {
                        SearchForUserMenu.SearchForOtherUser(user);
                        break;
                    }
                case 8:
                    {
                        NotificationsMenu.ShowNotifications(user);
                        break;
                    }
                case 9:
                    {
                        Console.WriteLine("Logging out......");
                        Menu.Start();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong choice, please try again!");
                        ShowBalance(user);
                        break;
                    }
            }

        }

    }
}
