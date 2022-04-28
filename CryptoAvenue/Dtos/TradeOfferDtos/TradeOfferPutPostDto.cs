namespace CryptoAvenue.Dtos.TradeOfferDtos
{
    public class TradeOfferPutPostDto
    {
        public double SentAmount { get; set; }
        public double ReceivedAmount { get; set; }
        public Guid SenderID { get; set; }
        public Guid RecipientID { get; set; }
        public Guid SentCoinID { get; set; }
        public Guid ReceivedCoinID { get; set; }
    }
}
