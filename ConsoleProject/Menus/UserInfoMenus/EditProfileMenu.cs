using ConsoleProject.BLL;
using ConsoleProject.Domain;
using ConsoleProject.StrategyPatterm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.UserInfoMenus
{
    public class EditProfileMenu
    {
        public static void EditProfile(User user)
        {

            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine("PROFILE EDITING PAGE");
            Console.WriteLine();

            Console.WriteLine("Your current credentials are:");

            var db = new CryptoAvenueContext();
            var foundUser = db.Users.Where(x => x == user).FirstOrDefault();

            Console.WriteLine(foundUser.ToString());

            Console.WriteLine("What do you wish to change?");
            Console.WriteLine("Press 1 for changing your email.");
            Console.WriteLine("Press 2 for changing your password.");
            Console.WriteLine("Press 3 for changing your security question and answer.");

            Console.WriteLine("Press 0 for going back to the Balance page");

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
                        Console.WriteLine("Please enter your new email adress:");
                        var newEmail = Console.ReadLine();

                        AccountBusinessLogic.UpdateUserEmail(user, newEmail);

                        Console.WriteLine("Email succesfully changed!");

                        EditProfile(user);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Please enter your new password:");
                        var newPassword = Console.ReadLine();

                        AccountBusinessLogic.UpdateUserPassword(user, newPassword);

                        Console.WriteLine("Password succesfully changed!");

                        EditProfile(user);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Please enter your new security question:");
                        var newQuestion = Console.ReadLine();

                        Console.WriteLine("Please enter your new security answer:");
                        var newAnswer = Console.ReadLine();

                        AccountBusinessLogic.UpdateUserQnA(user, newQuestion, newAnswer);

                        Console.WriteLine("Security question and answer succesfully changed!");

                        EditProfile(user);
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Wrong choice, please try again!");
                        EditProfile(user);
                        break;
                    }
            }


        }
    }
}
