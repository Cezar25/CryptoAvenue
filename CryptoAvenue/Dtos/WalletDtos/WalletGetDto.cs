namespace CryptoAvenue.Dtos.WalletDtos
{
    public class WalletGetDto
    {
        public Guid Id { get; set; }
        public Guid CoinID { get; set; }
        public Guid UserID { get; set; }
        public double CoinAmount { get; set; }
    }
}
