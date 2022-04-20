using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.StrategyPatterm
{
    public class ShowBalanceContext
    {
        private IShowBalanceStrategy _strategy;

        public void SetStrategy(IShowBalanceStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ShowBalance(User user)
        {
            if (_strategy == null)
                Console.WriteLine("No strategy selected!");
            else
                _strategy.ShowBalance(user);
        }

    }
}
