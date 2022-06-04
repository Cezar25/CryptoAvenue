﻿using CryptoAvenue.Domain.Models;
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
        public Guid SenderId { get; set; }
        public Guid RecipientId { get; set; }
        public Guid SentCoinId { get; set; }
        public Guid ReceivedCoinId { get; set; }
        public double SentAmount { get; set; }
        //public double ReceivedAmount { get; set; }
    }
}
