using CryptoAvenue.Application.Queries.TradeOfferQueries;
using CryptoAvenue.Dal;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.QueryHandlers.TradeOfferQueryHandlers
{
    public class GetTradeOffersBySenderIDHandler : IRequestHandler<GetTradeOffersBySenderID, List<TradeOffer>>
    {
        private readonly CryptoAvenueContext context;

        public GetTradeOffersBySenderIDHandler(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public async Task<List<TradeOffer>> Handle(GetTradeOffersBySenderID request, CancellationToken cancellationToken)
        {
            var tradeOffers = context.Offers.Where(x => x.SenderID == request.SenderID).ToList();
            return tradeOffers;
        }
    }
}
