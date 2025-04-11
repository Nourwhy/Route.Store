using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class GeneircRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _context;

        public GeneircRepository(StoreDbContext context) 
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
         await _context.AddAsync(entity);
        }

        public void Delete(TKey id)
        {
            _context.Remove(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackchanges = false)
        {
            return trackchanges ?
                  await _context.Products.Include(P => P.ProductBrand).Include(P => P.ProductType).ToListAsync() as  IEnumerable<TEntity>
                : await _context.Products.Include(P => P.ProductBrand).Include(P => P.ProductType).AsNoTracking().ToListAsync() as IEnumerable<TEntity>;
                
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            return await _context.Products.Include(P => P.ProductBrand).Include(P => P.ProductType).FirstOrDefaultAsync(P=>P.Id == id as int? ) as TEntity;
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
