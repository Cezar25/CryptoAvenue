using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Domain.Models
{
    public class Coin : BaseEntity
    {
        public string Name { get; set; }
        public string Abreviation { get; set; }
        public double ValueInEUR { get; set; }
        public double ValueInUSD { get; set; }
        public double ValueInBTC { get; set; }

        #region Nav Properties 
        public ICollection<TradeOffer> OffersSent { get; set; } = new List<TradeOffer>();
        public ICollection<TradeOffer> OffersReceived { get; set; } = new List<TradeOffer>();
        #endregion

        #region Equals() and GetHashCode()
        public override bool Equals(object? obj)
        {
            return obj is Coin coin &&
                   Id.Equals(coin.Id) &&
                   Name == coin.Name &&
                   Abreviation == coin.Abreviation &&
                   ValueInEUR == coin.ValueInEUR &&
                   ValueInUSD == coin.ValueInUSD &&
                   ValueInBTC == coin.ValueInBTC;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Abreviation, ValueInEUR, ValueInUSD, ValueInBTC);
        }
        #endregion
    }
}
