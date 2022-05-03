using CryptoAvenue.Application.Commands.UserWalletCommands;
using CryptoAvenue.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.CommandHandlers.UserWalletCommandHandlers
{
    public class GetTotalUserWalletsValueBTCHandler : IRequestHandler<GetTotalUserWalletsValueBTC, double>
    {
        private readonly IWalletRepository repository;
        public GetTotalUserWalletsValueBTCHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public Task<double> Handle(GetTotalUserWalletsValueBTC request, CancellationToken cancellationToken)
        {
            double totalUserWalletsValueBTC = 0;

            foreach (var wallet in repository.GetWalletsByUserID(request.UserId, true))
            {
                totalUserWalletsValueBTC += wallet.CoinType.ValueInBTC * wallet.CoinAmount;
            }

            return Task.FromResult(totalUserWalletsValueBTC);
        }
    }
}
