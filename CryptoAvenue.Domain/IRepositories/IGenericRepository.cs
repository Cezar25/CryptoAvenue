using CryptoAvenue.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Domain.IRepositories
{
    public interface IGenericRepository <T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        T GetEntityByID(Guid id);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        void SaveChanges();
    }
}
