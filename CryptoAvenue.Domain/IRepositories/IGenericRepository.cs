using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Domain.IRepositories
{
    public interface IGenericRepository <T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetEntityByID(Guid id);
        void Insert(T entity);
        void Delete(Guid id);
        void Update(T entity);
        void Save();
        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}
