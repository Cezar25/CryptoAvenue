using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Dal.Repositories
{
    public class TradeOfferRepository : ITradeOfferRepository
    {
        private readonly CryptoAvenueContext context;

        public TradeOfferRepository(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public void DeleteWallet(Guid tradeOfferID)
        {
            Wallet wallet = context.Wallets.FirstOrDefault(x => x.WalletID == tradeOfferID);
            context.Wallets.Remove(wallet);
        }

        public TradeOffer GetOfferByID(Guid tradeOfferID)
        {
            return context.Offers.Find(tradeOfferID);
        }

        public IEnumerable<TradeOffer> GetOffers()
        {
            return context.Offers.ToList();
        }

        public IEnumerable<TradeOffer> GetOffersByReceivedCoinID(Guid receivedCoinID)
        {
            return context.Offers.Where(x => x.ReceivedCoinID == receivedCoinID).ToList();
        }

        public IEnumerable<TradeOffer> GetOffersByRecipientID(Guid recipientID)
        {
            return context.Offers.Where(x => x.RecipientID == recipientID).ToList();
        }

        public IEnumerable<TradeOffer> GetOffersBySenderID(Guid senderID)
        {
            return context.Offers.Where(x => x.SenderID == senderID).ToList();
        }

        public IEnumerable<TradeOffer> GetOffersBySentCoinID(Guid sentCoinID)
        {
            return context.Offers.Where(x => x.SentCoinID == sentCoinID).ToList();
        }

        public void InsertWallet(TradeOffer tradeOffer)
        {
            context.Add(tradeOffer);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateWallet(TradeOffer tradeOffer)
        {
            context.Entry(tradeOffer).State = EntityState.Modified;
        }
    }
}
