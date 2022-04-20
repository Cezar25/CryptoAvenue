using ConsoleProject.Domain;
using ConsoleProject.StrategyPatterm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.UserInfoMenus
{
    public class RegisterMenu
    {
        public static void Register()
        {
            Console.Clear();
            Console.WriteLine("WELCOME TO THE REGISTER PAGE!");

            Console.WriteLine("Please type in your email:");
            string inputEmail = Console.ReadLine();

            Console.WriteLine("Please type in your password:");
            string inputPassword = Console.ReadLine();

            Console.WriteLine("Please type in your age:");
            int inputAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please type in your security question:");
            string inputQuestion = Console.ReadLine();

            Console.WriteLine("Please type in your security question answer:");
            string inputAnswer = Console.ReadLine();

            Console.WriteLine("You have succesfully registered!");

            var cryptoAvenueContext = new CryptoAvenueContext();

            cryptoAvenueContext.Add(new User(inputEmail, inputPassword, inputAge, inputQuestion, inputAnswer));
            cryptoAvenueContext.SaveChanges();

            var context = new ShowBalanceContext();
            context.SetStrategy(new ShownBalanceStrategy());
            context.ShowBalance(cryptoAvenueContext.Users.SingleOrDefault(x => x.Email == inputEmail));
        }
    }
}
