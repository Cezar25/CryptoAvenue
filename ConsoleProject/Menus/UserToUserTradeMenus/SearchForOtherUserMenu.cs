using ConsoleProject.BLL;

using ConsoleProject.Domain;
using ConsoleProject.StrategyPatterm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.UserToUserTradeMenus
{
    public class SearchForUserMenu
    {
        public static void SearchForOtherUser(User user)
        {
            var db = new CryptoAvenueContext();

            var context = new ShowBalanceContext();
            context.SetStrategy(new ShownBalanceStrategy());

            Console.Clear();
            Console.WriteLine("Please type in the email of the user you are searching for:");

            var searchedEmail = Console.ReadLine();

            if (db.Users.Any(x => x.Email == searchedEmail) && db.Users.FirstOrDefault(x => x.Email == searchedEmail).PrivateProfile == false)
            {
                var searchedUser = db.Users.FirstOrDefault(x => x.Email == searchedEmail);

                if (searchedUser.Email == user.Email)
                {
                    Console.WriteLine("You cannot search for yourself! Please try again!");
                    SearchForOtherUser(user);
                }
                else
                {
                    //UserPortofolioBusinessLogic.DisplayCoinPercentage(searchedUser);
                    UserPortofolioBusinessLogic.DisplayPortofolio(searchedUser);

                    Console.WriteLine("Press 1 for sending the user a trade offer.");
                    Console.WriteLine("Press 2 for viewing user's portofolio %.");
                    Console.WriteLine("Press 0 for going back to the BALANCE page");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 0:
                            {
                                context.ShowBalance(user);
                                break;
                            }
                        case 1:
                            {
                                SendTradeOfferMenu.SendTradeOffer(user, searchedUser);

                                break;
                            }
                        case 2:
                            {
                                ViewUserPortofolioPercentageMenu.PortofolioPercentageMenu(user, searchedUser);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Wrong choice! Please try again!");
                                SearchForOtherUser(user);
                                break;
                            }
                    }

                    context.ShowBalance(user);
                }

            }

            else
            {
                Console.WriteLine("The email you searched doesn't belong to any user or the user has a PRIVATE profile.");
                Console.WriteLine("Press 1 for trying again.");
                Console.WriteLine("Press 2 for going back to the BALANCE page.");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            SearchForOtherUser(user);
                            break;
                        }
                    case 2:
                        {
                            context.ShowBalance(user);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong choice! Please try again!");
                            SearchForOtherUser(user);
                            break;
                        }
                }
            }
        }
    }
}
