using System;
using System.Linq.Expressions;

namespace EFDataAccessLibrary.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<List<T>> ReadAllAsync();
    }
}

