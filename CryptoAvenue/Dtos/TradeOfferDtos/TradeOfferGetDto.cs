using CryptoAvenue.Domain.Models;

namespace CryptoAvenue.Dtos.TradeOfferDtos
{
    public class TradeOfferGetDto
    {
        public Guid Id { get; set; }
        public double SentAmount { get; set; }
        public double ReceivedAmount { get; set; }
        public Guid SenderID { get; set; }
        public User Sender { get; set; }
        public Guid RecipientID { get; set; }
        public User Recipient { get; set; }
        public Guid SentCoinID { get; set; }
        public Coin SentCoin { get; set; }
        public Guid ReceivedCoinID { get; set; }
        public Coin ReceivedCoin { get; set; }
    }
}
