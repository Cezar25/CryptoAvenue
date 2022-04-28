using System.ComponentModel.DataAnnotations;

namespace CryptoAvenue.Dtos
{
    public class CoinPutPostDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string Abreviation { get; set; }

        [Required]
        public double ValueInEUR { get; set; }

        [Required]
        public double ValueInUSD { get; set; }

        [Required]
        public double ValueInBTC { get; set; }
    }
}
