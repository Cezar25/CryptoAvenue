using CryptoAvenue.Application.Queries.TradeOfferQueries;
using CryptoAvenue.Dal;
using CryptoAvenue.Domain.IRepositories;
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
        private readonly ITradeOfferRepository repository;

        public GetTradeOfferByIDHandler(ITradeOfferRepository repository)
        {
            this.repository = repository;
        }

        public Task<TradeOffer> Handle(GetTradeOfferByID request, CancellationToken cancellationToken)
        {
            var tradeOffer = repository.GetEntityByID(request.TradeOfferId);
            return Task.FromResult(tradeOffer);
        }
    }
}
