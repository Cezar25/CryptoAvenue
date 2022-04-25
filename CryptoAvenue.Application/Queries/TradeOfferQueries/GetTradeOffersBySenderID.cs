using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Queries.TradeOfferQueries
{
    public class GetTradeOffersBySenderID : IRequest<List<TradeOffer>>
    {
        public Guid SenderId { get; set; }
    }
}
