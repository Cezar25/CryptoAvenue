using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Domain
{
    public class Coin
    {
        public string Name { get; set; }
        public string Abreviation { get; set; }
        public double ValueInEUR { get; set; }
        public double ValueInUSD { get; set; }
        public double ValueInBTC { get; set; }
        public Guid CoinID { get; set; } = Guid.NewGuid();

        public Coin(string name, string abreviation, double valueInEUR, double valueInUSD, double valueInBTC)
        {
            Name = name;
            Abreviation = abreviation;
            ValueInEUR = valueInEUR;
            ValueInUSD = valueInUSD;
            ValueInBTC = valueInBTC;
        }

        public Coin(string name, string abreviation)
        {
            Name = name;
            Abreviation = abreviation;
        }
        #region Nav Properties 
        public ICollection<TradeOffer> OffersSent { get; set; } = new List<TradeOffer>();
        public ICollection<TradeOffer> OffersReceived { get; set; } = new List<TradeOffer>();

        public override bool Equals(object obj)
        {
            return obj is Coin coin &&
                   Name == coin.Name &&
                   Abreviation == coin.Abreviation &&
                   ValueInEUR == coin.ValueInEUR &&
                   ValueInUSD == coin.ValueInUSD &&
                   ValueInBTC == coin.ValueInBTC &&
                   CoinID.Equals(coin.CoinID) &&
                   EqualityComparer<ICollection<TradeOffer>>.Default.Equals(OffersSent, coin.OffersSent) &&
                   EqualityComparer<ICollection<TradeOffer>>.Default.Equals(OffersReceived, coin.OffersReceived);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Abreviation, ValueInEUR, ValueInUSD, ValueInBTC, CoinID, OffersSent, OffersReceived);
        }
        #endregion
    }
}
