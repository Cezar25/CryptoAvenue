using CryptoAvenue.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Domain.IRepositories
{
    public interface ITradeOfferRepository : IGenericRepository<TradeOffer>
    {
        IEnumerable<TradeOffer> GetOffersBySenderID(Guid senderID, bool includeAll = false);
        IEnumerable<TradeOffer> GetOffersByRecipientID(Guid recipientID, bool includeAll = false);
        IEnumerable<TradeOffer> GetOffersBySentCoinID(Guid sentCoinID, bool includeAll = false);
        IEnumerable<TradeOffer> GetOffersByReceivedCoinID(Guid receivedCoinID, bool includeAll = false);
        TradeOffer GetTradeOfferById(Guid id);
    }
}
