using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Queries.TradeOfferQueries
{
    public class GetTradeOfferDetails2 : IRequest<string>
    {
        public Guid SentCoinId { get; set; }
        public Guid ReceivedCoinId { get; set; }
        public double SentAmount { get; set; }
    }
}
