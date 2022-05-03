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

        public IEnumerable<TradeOffer> GetOffersByReceivedCoinID(Guid receivedCoinID, bool includeAll = false)
        {
            var query = context.Offers.Where(x => x.ReceivedCoinID == receivedCoinID);
            if(includeAll == true)
            {
                query = query.Include(x => x.Sender).Include(x => x.Recipient).Include(x => x.SentCoin).Include(x => x.ReceivedCoin);
            }

            return query.ToList();
        }

        public IEnumerable<TradeOffer> GetOffersByRecipientID(Guid recipientID, bool includeAll = false)
        {
            var query = context.Offers.Where(x => x.RecipientID == recipientID);
            if(includeAll == true)
            {
                query = query.Include(x => x.Sender).Include(x => x.Recipient).Include(x => x.SentCoin).Include(x => x.ReceivedCoin);
            }

            return query.ToList();
        }

        public IEnumerable<TradeOffer> GetOffersBySenderID(Guid senderID, bool includeAll = false)
        {
            var query = context.Offers.Where(x => x.SenderID == senderID);
            if(includeAll == true)
            {
                query = query.Include(x => x.Sender).Include(x => x.Recipient).Include(x => x.SentCoin).Include(x => x.ReceivedCoin);
            }

            return query.ToList();
        }

        public IEnumerable<TradeOffer> GetOffersBySentCoinID(Guid sentCoinID, bool includeAll = false)
        {
            var query = context.Offers.Where(x => x.SentCoinID == sentCoinID);
            if (includeAll == true)
            {
                query = query.Include(x => x.Sender).Include(x => x.Recipient).Include(x => x.SentCoin).Include(x => x.ReceivedCoin);
            }

            return query.ToList();
        }
    }
}
