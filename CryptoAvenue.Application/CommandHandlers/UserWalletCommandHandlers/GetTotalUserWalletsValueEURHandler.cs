using CryptoAvenue.Application.Commands.UserWalletCommands;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.CommandHandlers.UserWalletCommandHandlers
{
    public class GetTotalUserWalletsValueEURHandler : IRequestHandler<GetTotalUserWalletsValueEUR, double>
    {
        private readonly IWalletRepository repository;

        public GetTotalUserWalletsValueEURHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public Task<double> Handle(GetTotalUserWalletsValueEUR request, CancellationToken cancellationToken)
        {
            double totalUserWalletsValueEUR = 0;

            foreach (var wallet in repository.GetWalletsByUserID(request.UserId))
            {
                totalUserWalletsValueEUR += wallet.CoinType.ValueInEUR * wallet.CoinAmount;
            }

            return Task.FromResult(totalUserWalletsValueEUR);
        }
    }
}
