using ConsoleProject.Domain;
using ConsoleProject.Menus.AppTradeMenus;
using ConsoleProject.Menus.BalanceMenus;
using ConsoleProject.StrategyPatterm;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.UserInfoMenus
{
    public class BalanceMenu
    {
        public static void Balance(User user)
        {
            var context = new ShowBalanceContext();
            context.SetStrategy(new ShownBalanceStrategy());
            context.ShowBalance(user);
        }
    }
}
