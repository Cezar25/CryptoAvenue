using CryptoAvenue.Application.Commands;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.CommandHandlers
{
    public class CreateTradeOfferHandler : IRequestHandler<CreateTradeOffer, TradeOffer>
    {
        private readonly ITradeOfferRepository repository;

        public CreateTradeOfferHandler(ITradeOfferRepository repository)
        {
            this.repository = repository;
        }

        public Task<TradeOffer> Handle(CreateTradeOffer request, CancellationToken cancellationToken)
        {
            var tradeOffer = new TradeOffer()
            {
                SenderID = request.SenderId,
                RecipientID = request.RecipientId,
                SentCoinID = request.SentCoinId,
                ReceivedCoinID = request.ReceivedCoinId,
                SentAmount = request.SentAmount,
                ReceivedAmount = request.ReceivedAmount
            };

            if (tradeOffer == null) return null;

            repository.Insert(tradeOffer);
            repository.SaveChanges();

            return Task.FromResult(tradeOffer);
        }
    }
}
