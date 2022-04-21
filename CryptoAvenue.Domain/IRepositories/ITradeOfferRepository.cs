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
        IEnumerable<TradeOffer> GetOffersBySenderID(Guid senderID);
        IEnumerable<TradeOffer> GetOffersByRecipientID(Guid recipientID);
        IEnumerable<TradeOffer> GetOffersBySentCoinID(Guid sentCoinID);
        IEnumerable<TradeOffer> GetOffersByReceivedCoinID(Guid receivedCoinID);
    }
}
