using CryptoAvenue.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Domain.IRepositories
{
    public interface ICoinRepository : IGenericRepository<Coin>
    {
        Coin GetCoinByAbreviation(string abreviation);
        IEnumerable<Coin> GetAllCoinsByUserId(Guid userId);
    }
}
