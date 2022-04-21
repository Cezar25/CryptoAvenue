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
    public class GetTradeOffersBySentCoinIDHandler : IRequestHandler<GetTradeOffersBySentCoinID, List<TradeOffer>>
    {
        private readonly CryptoAvenueContext context;

        public GetTradeOffersBySentCoinIDHandler(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public async Task<List<TradeOffer>> Handle(GetTradeOffersBySentCoinID request, CancellationToken cancellationToken)
        {
            var tradeOffers = context.Offers.Where(x => x.SentCoinID == request.SentCoinID).ToList();
            return tradeOffers;
        }
    }
}
