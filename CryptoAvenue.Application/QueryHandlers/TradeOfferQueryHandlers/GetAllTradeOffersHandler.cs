using CryptoAvenue.Application.Queries;
using CryptoAvenue.Dal;
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
        private readonly CryptoAvenueContext context;

        public GetAllTradeOffersHandler(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public async Task<List<TradeOffer>> Handle(GetAllTradeOffers request, CancellationToken cancellationToken)
        {
            return await context.Offers.ToListAsync();
        }
    }
}
