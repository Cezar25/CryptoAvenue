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
    public class GetTradeOffersByReceivedCoinIDHandler : IRequestHandler<GetTradeOffersByReceivedCoinID, List<TradeOffer>>
    {
        private readonly ITradeOfferRepository repository;

        public GetTradeOffersByReceivedCoinIDHandler(ITradeOfferRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<TradeOffer>> Handle(GetTradeOffersByReceivedCoinID request, CancellationToken cancellationToken)
        {
            var tradeOffers = repository.GetAll().Where(x => x.ReceivedCoinID == request.ReceivedCoinId).ToList();
            return Task.FromResult(tradeOffers);
        }
    }
}
