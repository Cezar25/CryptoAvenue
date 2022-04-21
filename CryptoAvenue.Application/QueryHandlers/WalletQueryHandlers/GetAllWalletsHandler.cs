using CryptoAvenue.Application.Queries;
using CryptoAvenue.Dal;
using CryptoAvenue.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.QueryHandlers
{
    public class GetAllWalletsHandler : IRequestHandler<GetAllWallets, List<Wallet>>
    {
        private readonly CryptoAvenueContext context;

        public GetAllWalletsHandler(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public async Task<List<Wallet>> Handle(GetAllWallets request, CancellationToken cancellationToken)
        {
            return context.Wallets.ToList();
        }
    }
}
