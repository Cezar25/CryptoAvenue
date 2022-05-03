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
    public class DeleteCoinHandler : IRequestHandler<DeleteCoin, Coin>
    {
        private readonly ICoinRepository repository;

        public DeleteCoinHandler(ICoinRepository repository)
        {
            this.repository = repository;
        }

        public Task<Coin> Handle(DeleteCoin request, CancellationToken cancellationToken)
        {
            var coin = repository.GetEntityByID(request.CoinId);

            if (coin == null) return null;

            repository.Delete(coin);
            repository.SaveChanges();

            return Task.FromResult(coin);
        }
    }
}
