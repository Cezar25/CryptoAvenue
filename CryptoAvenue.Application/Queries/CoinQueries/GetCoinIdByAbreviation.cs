using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Queries.CoinQueries
{
    public class GetCoinIdByAbreviation : IRequest<Guid>
    {
        public string CoinAbreviation { get; set; }
    }
}
