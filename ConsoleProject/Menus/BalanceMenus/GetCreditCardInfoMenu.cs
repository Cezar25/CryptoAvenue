using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.BalanceMenus
{
    public class GetCreditCardInfoMenu
    {
        public static void GetCreditCardInfo(User user)
        {
            Console.Clear();
            Console.WriteLine("DEPOSIT PAGE");
            Console.WriteLine("Please type in your credit card number:");
            string cardNumber = Console.ReadLine();
            Console.WriteLine("Please type in your credit card's expiration month(1-12):");
            int cardExpirationMonth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please type in your credit card's expiration year:");
            int cardExpirationYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please type in your credit card's CVV:");
            int cardCVV = Convert.ToInt32(Console.ReadLine());

            DepositMenu.DepositMoney(user);
        }
    }
}
