using MediatR;
using CryptoAvenue.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Queries
{
    public class GetAllCoins : IRequest<List<Coin>>
    {
    }
}
