
using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Domain
{
    public class Wallet
    {
        public Guid WalletID { get; set; } = Guid.NewGuid();
        public Guid CoinID { get; set; }
        public Coin CoinType { get; set; }
        public Guid UserID { get; set; }
        public User WalletOwner { get; set; }
        public double CoinAmount { get; set; }

    }

}

