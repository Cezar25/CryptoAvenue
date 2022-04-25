using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Commands
{
    public class CreateTradeOffer : IRequest<TradeOffer>
    {
        public Guid SenderID { get; set; }
        public Guid RecipientID { get; set; }
        public Guid SentCoinID { get; set; }
        public Guid ReceivedCoinID { get; set; }
        public double SentAmount { get; set; }
        public double ReceivedAmount { get; set; }
    }
}
