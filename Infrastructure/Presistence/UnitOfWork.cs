using Domain.Contracts;
using Domain.Models;
using Presistence.Data;
using Presistence.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private readonly ConcurrentDictionary<string, object> _repositories;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
            _repositories=new ConcurrentDictionary<string, object>();
        }
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
      =>(IGenericRepository<TEntity, TKey>) _repositories.GetOrAdd(typeof(TEntity).Name, new GeneircRepository<TEntity, TKey>(_context));
        

        public async Task<int> SaveChangeAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
