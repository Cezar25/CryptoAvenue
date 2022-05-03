using CryptoAvenue.Application.Commands.TradeOfferCommands;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.CommandHandlers.TradeOfferCommandHandlers
{
    public class DeleteTradeOfferHandler : IRequestHandler<DeleteTradeOffer, TradeOffer>
    {
        private readonly ITradeOfferRepository repository;

        public DeleteTradeOfferHandler(ITradeOfferRepository repository)
        {
            this.repository = repository;
        }

        public Task<TradeOffer> Handle(DeleteTradeOffer request, CancellationToken cancellationToken)
        {
            var tradeOffer = repository.GetEntityBy(x => x.Id == request.TradeOfferId);

            if (tradeOffer == null) return null;

            repository.Delete(tradeOffer);
            repository.SaveChanges();

            return Task.FromResult(tradeOffer);
        }
    }
}
