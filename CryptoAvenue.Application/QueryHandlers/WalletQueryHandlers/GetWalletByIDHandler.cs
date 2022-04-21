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
    public class GetWalletByIDHandler : IRequestHandler<GetWalletByID, Wallet>
    {
        private readonly CryptoAvenueContext context;

        public GetWalletByIDHandler(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public async Task<Wallet> Handle(GetWalletByID request, CancellationToken cancellationToken)
        {
            var wallet = context.Wallets.SingleOrDefault(x => x.WalletID == request.WalletID);
            return wallet;
        }
    }
}
