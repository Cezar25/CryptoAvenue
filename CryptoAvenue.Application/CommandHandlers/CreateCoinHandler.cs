﻿using CryptoAvenue.Application.Queries;
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
    public class CreateCoinHandler : IRequestHandler<CreateCoin, Coin>
    {
        private readonly ICoinRepository repository;

        public CreateCoinHandler(ICoinRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Coin> Handle(CreateCoin request, CancellationToken cancellationToken)
        {
            var addedCoin = new Coin() { Name = request.Name , Abreviation = request.Abreviation, ValueInEUR = request.ValueInEUR, ValueInUSD = request.ValueInUSD, ValueInBTC = request.ValueInUSD};

            repository.InsertCoin(addedCoin);
            await repository.SaveAsync(cancellationToken);
            return addedCoin;
        }
    }
}
