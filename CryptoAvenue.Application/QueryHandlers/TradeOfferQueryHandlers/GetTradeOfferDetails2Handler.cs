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
    public class GetTradeOfferDetails2Handler : IRequestHandler<GetTradeOfferDetails2, string>
    {
        private readonly ICoinRepository coinRepository;

        public GetTradeOfferDetails2Handler(ICoinRepository coinRepository)
        {
            this.coinRepository = coinRepository;
        }

        public Task<string> Handle(GetTradeOfferDetails2 request, CancellationToken cancellationToken)
        {
            var sentCoin = coinRepository.GetEntityByID(request.SentCoinId);
            var receivedCoin = coinRepository.GetEntityByID(request.ReceivedCoinId);

            var receivedAmount = (request.SentAmount * sentCoin.ValueInEUR) / receivedCoin.ValueInEUR;
            var rate = receivedCoin.ValueInEUR / sentCoin.ValueInEUR;

            string details = "";
            details += $"{request.SentAmount} {sentCoin.Abreviation} for {receivedAmount} {receivedCoin.Abreviation}";
            details += "\n";
            details += $"1 {receivedCoin.Abreviation} for {rate} {sentCoin.Abreviation}";

            return Task.FromResult(details);
        }
    }
}
