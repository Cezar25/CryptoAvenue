using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Dal.Repositories
{
    public class CoinRepository : GenericRepository<Coin>, ICoinRepository
    {
        public CoinRepository(CryptoAvenueContext context) : base(context)
        {

        }
        public Coin GetCoinByAbreviation(string abreviation)
        {
            throw new NotImplementedException();
        }
    }
}
