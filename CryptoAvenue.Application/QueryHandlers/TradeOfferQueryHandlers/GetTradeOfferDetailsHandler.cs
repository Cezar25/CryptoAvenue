using CryptoAvenue.Application.Queries.TradeOfferQueries;
using CryptoAvenue.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.QueryHandlers.TradeOfferQueryHandlers
{
    public class GetTradeOfferDetailsHandler : IRequestHandler<GetTradeOfferDetails, string>
    {
        private readonly ITradeOfferRepository repository;

        public GetTradeOfferDetailsHandler(ITradeOfferRepository repository)
        {
            this.repository = repository;
        }

        public Task<string> Handle(GetTradeOfferDetails request, CancellationToken cancellationToken)
        {
            //var tradeOffer = repository.GetEntityByID(request.TradeOfferId);
            var tradeOffer = repository.GetTradeOfferById(request.TradeOfferId);

            String details = null;

            details += $"{tradeOffer.SentAmount} {tradeOffer.SentCoin.Abreviation} for {tradeOffer.ReceivedAmount} {tradeOffer.ReceivedCoin.Abreviation}";
            details += "\n";

            var rate = tradeOffer.SentCoin.ValueInEUR / tradeOffer.ReceivedCoin.ValueInEUR;

            details += $"1 {tradeOffer.SentCoin.Abreviation} for {rate} {tradeOffer.ReceivedCoin.Abreviation}";

            return Task.FromResult(details);
        }
    }
}
