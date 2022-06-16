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
    public class GetTradeOffersByRecipientIDHandler : IRequestHandler<GetTradeOffersByRecipientID, List<TradeOffer>>
    {
        private readonly ITradeOfferRepository repository;

        public GetTradeOffersByRecipientIDHandler(ITradeOfferRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<TradeOffer>> Handle(GetTradeOffersByRecipientID request, CancellationToken cancellationToken)
        {
            var tradeOffers = repository.GetOffersByRecipientID(request.RecipientId).ToList();
            return Task.FromResult(tradeOffers);
        }
    }
}
