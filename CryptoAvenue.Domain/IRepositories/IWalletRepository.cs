using CryptoAvenue.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Domain.IRepositories
{
    public interface IWalletRepository : IGenericRepository<Wallet>
    {
        IEnumerable<Wallet> GetWalletsByUserID(Guid userID, bool includeAll = false);
        IEnumerable<Wallet> GetWalletsByCoinID(Guid coinID, bool includeAll = false);
        Dictionary<Coin, double> GetCoinPercentage(Guid userId);
        Wallet GetWalletByIdIncluded(Guid id);
        Wallet GetWalletByIncluded(Expression<Func<Wallet, bool>> predicate);
    }
}
