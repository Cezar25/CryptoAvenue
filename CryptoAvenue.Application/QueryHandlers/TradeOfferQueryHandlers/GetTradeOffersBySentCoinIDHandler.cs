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
    public class GetTradeOffersBySentCoinIDHandler : IRequestHandler<GetTradeOffersBySentCoinID, List<TradeOffer>>
    {
        private readonly ITradeOfferRepository repository;

        public GetTradeOffersBySentCoinIDHandler(ITradeOfferRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<TradeOffer>> Handle(GetTradeOffersBySentCoinID request, CancellationToken cancellationToken)
        {
            var tradeOffers = repository.FindAll(x => x.SentCoinID == request.SentCoinId).ToList();
            return Task.FromResult(tradeOffers);
        }
    }
}
