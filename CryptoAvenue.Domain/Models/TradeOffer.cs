using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Domain.Models
{
    public class TradeOffer : BaseEntity
    {
        public User Sender { get; set; }
        public User Recipient { get; set; }
        public Coin SentCoin { get; set; }
        public double SentAmount { get; set; }
        public Coin ReceivedCoin { get; set; }
        public double ReceivedAmount { get; set; }
        public Guid SenderID { get; set; }
        public Guid RecipientID { get; set; }
        public Guid SentCoinID { get; set; }
        public Guid ReceivedCoinID { get; set; }

        #region Equals() and GetHashCode()
        public override bool Equals(object? obj)
        {
            return obj is TradeOffer offer &&
                   Id.Equals(offer.Id) &&
                   EqualityComparer<User>.Default.Equals(Sender, offer.Sender) &&
                   EqualityComparer<User>.Default.Equals(Recipient, offer.Recipient) &&
                   EqualityComparer<Coin>.Default.Equals(SentCoin, offer.SentCoin) &&
                   SentAmount == offer.SentAmount &&
                   EqualityComparer<Coin>.Default.Equals(ReceivedCoin, offer.ReceivedCoin) &&
                   ReceivedAmount == offer.ReceivedAmount &&
                   SenderID.Equals(offer.SenderID) &&
                   RecipientID.Equals(offer.RecipientID) &&
                   SentCoinID.Equals(offer.SentCoinID) &&
                   ReceivedCoinID.Equals(offer.ReceivedCoinID);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Sender);
            hash.Add(Recipient);
            hash.Add(SentCoin);
            hash.Add(SentAmount);
            hash.Add(ReceivedCoin);
            hash.Add(ReceivedAmount);
            hash.Add(SenderID);
            hash.Add(RecipientID);
            hash.Add(SentCoinID);
            hash.Add(ReceivedCoinID);
            return hash.ToHashCode();
        }
        #endregion

        #region ToString()
        public override string ToString()
        {
            return $"From {Sender.Email} to {Recipient.Email}:\nCoin type: {SentCoin.Abreviation} amount: {SentAmount} for\nCoin type: {ReceivedCoin.Abreviation} amount: {ReceivedAmount}";
        }
        #endregion
    }
}
