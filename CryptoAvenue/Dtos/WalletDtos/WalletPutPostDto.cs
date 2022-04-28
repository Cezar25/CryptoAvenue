namespace CryptoAvenue.Dtos.WalletDtos
{
    public class WalletPutPostDto
    {
        public Guid CoinID { get; set; }
        public Guid UserID { get; set; }
        public double CoinAmount { get; set; }
    }
}
