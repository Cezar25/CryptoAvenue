using System.ComponentModel.DataAnnotations;

namespace CryptoAvenue.Dtos.TradeOfferDtos
{
    public class TradeOfferPutPostDto
    {
        [Required]
        public double SentAmount { get; set; }

        [Required]
        public double ReceivedAmount { get; set; }

        [Required]
        public Guid SenderID { get; set; }

        [Required]
        public Guid RecipientID { get; set; }

        [Required]
        public Guid SentCoinID { get; set; }

        [Required]
        public Guid ReceivedCoinID { get; set; }
    }
}
