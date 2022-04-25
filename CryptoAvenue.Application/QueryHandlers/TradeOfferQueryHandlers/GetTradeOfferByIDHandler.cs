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
    public class GetTradeOfferByIDHandler : IRequestHandler<GetTradeOfferByID, TradeOffer>
    {
        private readonly CryptoAvenueContext context;
        public GetTradeOfferByIDHandler(CryptoAvenueContext context)
        {
            this.context = context;
        }
        public async Task<TradeOffer> Handle(GetTradeOfferByID request, CancellationToken cancellationToken)
        {
            var tradeOffer = context.Offers.SingleOrDefault(x => x.Id == request.TradeOfferID);
            return tradeOffer;
        }
    }
}
