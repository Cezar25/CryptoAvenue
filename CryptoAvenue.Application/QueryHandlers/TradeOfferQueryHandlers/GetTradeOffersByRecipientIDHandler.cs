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
    public class GetTradeOffersByRecipientIDHandler : IRequestHandler<GetTradeOffersByRecipientID, List<TradeOffer>>
    {
        private readonly CryptoAvenueContext context;

        public GetTradeOffersByRecipientIDHandler(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public async Task<List<TradeOffer>> Handle(GetTradeOffersByRecipientID request, CancellationToken cancellationToken)
        {
            var tradeOffers = context.Offers.Where(x => x.RecipientID == request.RecipientID).ToList();
            return tradeOffers;
        }
    }
}
