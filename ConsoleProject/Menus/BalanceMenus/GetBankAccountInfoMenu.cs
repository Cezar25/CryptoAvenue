using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.BalanceMenus
{
    public class GetBankAccountInfoMenu
    {
        public static void GetBankAccountInfo(User user)
        {
            Console.Clear();

            Console.WriteLine("Please enter your account IBAN number: (using ints)");
            int bankAccountId = Convert.ToInt32(Console.ReadLine());

            WithdrawMenu.WithdrawMoney(user);
        }
    }
}
