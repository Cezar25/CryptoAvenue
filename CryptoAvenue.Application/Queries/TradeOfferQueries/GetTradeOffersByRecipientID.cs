﻿using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Queries.TradeOfferQueries
{
    public class GetTradeOffersByRecipientID : IRequest<List<TradeOffer>>
    {
        public Guid RecipientID { get; set; }
    }
}
