using CryptoAvenue.Application.Commands.CoinCommands;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.CommandHandlers.CoinCommandHandlers
{
    public class UpdateCoinHandler : IRequestHandler<UpdateCoin, Coin>
    {
        private readonly ICoinRepository repository;

        public UpdateCoinHandler(ICoinRepository repository)
        {
            this.repository = repository;
        }

        public Task<Coin> Handle(UpdateCoin request, CancellationToken cancellationToken)
        {
            var updated = new Coin();
            updated.Name = request.Name;
            updated.Abreviation = request.Abreviation;
            updated.ValueInEUR = request.ValueInEUR;
            updated.ValueInUSD = request.ValueInUSD;
            updated.ValueInBTC = request.ValueInBTC;

            repository.Update(updated);
            repository.SaveChanges();

            return Task.FromResult(updated);
        }
    }
}
