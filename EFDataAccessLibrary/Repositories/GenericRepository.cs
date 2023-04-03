using System;
using EFDataAccessLibrary.Interfaces;
using EFDataAccessLibrary.DataAccess;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ContactContext _context;
        public GenericRepository(ContactContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
       
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task<List<T>> ReadAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}

