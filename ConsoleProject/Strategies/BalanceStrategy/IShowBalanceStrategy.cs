using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.StrategyPatterm
{
    public interface IShowBalanceStrategy
    {
        public void ShowBalance(User user);
    }
}
