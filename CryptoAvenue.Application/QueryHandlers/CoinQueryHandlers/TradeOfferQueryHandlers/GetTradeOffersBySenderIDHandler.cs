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
    public class GetTradeOffersBySenderIDHandler : IRequestHandler<GetTradeOffersBySenderID, List<TradeOffer>>
    {
        private readonly ITradeOfferRepository repository;

        public GetTradeOffersBySenderIDHandler(ITradeOfferRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<TradeOffer>> Handle(GetTradeOffersBySenderID request, CancellationToken cancellationToken)
        {
            var tradeOffers = repository.GetAll().Where(x => x.SenderID == request.SenderId).ToList();
            return Task.FromResult(tradeOffers);
        }
    }
}
