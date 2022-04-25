using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Domain.Models
{
    public class Wallet : BaseEntity
    {
        public Guid CoinID { get; set; }
        public Coin CoinType { get; set; }
        public Guid UserID { get; set; }
        public User WalletOwner { get; set; }
        public double CoinAmount { get; set; }

        #region Equals() and GetHasCode()
        public override bool Equals(object? obj)
        {
            return obj is Wallet wallet &&
                   Id.Equals(wallet.Id) &&
                   CoinID.Equals(wallet.CoinID) &&
                   EqualityComparer<Coin>.Default.Equals(CoinType, wallet.CoinType) &&
                   UserID.Equals(wallet.UserID) &&
                   EqualityComparer<User>.Default.Equals(WalletOwner, wallet.WalletOwner) &&
                   CoinAmount == wallet.CoinAmount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CoinID, CoinType, UserID, WalletOwner, CoinAmount);
        }
        #endregion
    }
}
