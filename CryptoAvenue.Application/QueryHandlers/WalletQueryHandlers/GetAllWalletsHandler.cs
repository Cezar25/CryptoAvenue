using CryptoAvenue.Application.Queries;
using CryptoAvenue.Dal;
using CryptoAvenue.Domain.IRepositories;
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
        private readonly IWalletRepository repository;

        public GetAllWalletsHandler(IWalletRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Wallet>> Handle(GetAllWallets request, CancellationToken cancellationToken)
        {
            return repository.GetAll().ToList();
        }
    }
}
