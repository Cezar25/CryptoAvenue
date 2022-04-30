using System.ComponentModel.DataAnnotations;

namespace CryptoAvenue.Dtos.WalletDtos
{
    public class WalletPutPostDto
    {
        [Required]
        public Guid CoinID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        public double CoinAmount { get; set; }
    }
}
