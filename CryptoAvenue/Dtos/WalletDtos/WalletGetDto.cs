using CryptoAvenue.Domain.Models;

namespace CryptoAvenue.Dtos.WalletDtos
{
    public class WalletGetDto
    {
        public Guid Id { get; set; }
        public Guid CoinID { get; set; }
        public Coin Coin { get; set; }
        public Guid UserID { get; set; }
        public User WalletOwner { get; set; }
        public double CoinAmount { get; set; }
    }
}
