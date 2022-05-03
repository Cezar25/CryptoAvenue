using CryptoAvenue.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace CryptoAvenue.Dtos.WalletDtos
{
    public class WalletPutPostDto
    {
        [Required]
        public Guid CoinID { get; set; }

        //public Coin Coin { get; set; }

        [Required]
        public Guid UserID { get; set; }
        
        //public User WalletOwner { get; set; }

        [Required]
        public double CoinAmount { get; set; }
    }
}
