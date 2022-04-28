namespace CryptoAvenue.Dtos
{
    public class CoinGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abreviation { get; set; }
        public double ValueInEUR { get; set; }
        public double ValueInUSD { get; set; }
        public double ValueInBTC { get; set; }
    }
}
