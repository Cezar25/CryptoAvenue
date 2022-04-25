using CryptoAvenue.Application.Queries;
using CryptoAvenue.Dal;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.QueryHandlers.TradeOfferQueryHandlers
{
    public class GetAllTradeOffersHandler : IRequestHandler<GetAllTradeOffers, List<TradeOffer>>
    {
        private readonly ITradeOfferRepository repository;

        public GetAllTradeOffersHandler(ITradeOfferRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<TradeOffer>> Handle(GetAllTradeOffers request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.GetAll().ToList());
        }
    }
}
