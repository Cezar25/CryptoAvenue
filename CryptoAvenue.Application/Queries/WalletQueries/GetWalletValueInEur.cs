using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Queries.WalletQueries
{
    public class GetWalletValueInEur : IRequest<double>
    {
        public Guid WalletId { get; set; }
    }
}
