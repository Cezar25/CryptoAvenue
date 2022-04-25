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
    public class TradeOfferRepository : GenericRepository<TradeOffer>, ITradeOfferRepository
    {
        public TradeOfferRepository(CryptoAvenueContext context) : base(context)
        {
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
    }
}
