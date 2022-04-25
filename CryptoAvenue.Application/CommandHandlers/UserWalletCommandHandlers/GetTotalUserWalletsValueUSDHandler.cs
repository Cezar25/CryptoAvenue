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
    public class GetTotalUserWalletsValueUSDHandler : IRequestHandler<GetTotalUserWalletsValueUSD, double>
    {
        private readonly IWalletRepository repository;

        public GetTotalUserWalletsValueUSDHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public Task<double> Handle(GetTotalUserWalletsValueUSD request, CancellationToken cancellationToken)
        {
            double totalUserWalletsValueUSD = 0;

            foreach (var wallet in repository.GetWalletsByUserID(request.UserId))
            {
                totalUserWalletsValueUSD += wallet.CoinType.ValueInUSD * wallet.CoinAmount;
            }

            return Task.FromResult(totalUserWalletsValueUSD);
        }
    }
}
