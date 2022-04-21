using CryptoAvenue.Application.Queries.WalletQueries;
using CryptoAvenue.Dal;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.QueryHandlers.WalletQueryHandlers
{
    public class GetWalletsByUserIDHandler : IRequestHandler<GetWalletsByUserID, List<Wallet>>
    {
        private readonly CryptoAvenueContext context;

        public GetWalletsByUserIDHandler(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public async Task<List<Wallet>> Handle(GetWalletsByUserID request, CancellationToken cancellationToken)
        {
            var wallets = context.Wallets.Where(x => x.UserID == request.UserID).ToList();
            return wallets;
        }
    }
}
