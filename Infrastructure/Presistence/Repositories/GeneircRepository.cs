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
            var entity = _context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false)
        {
            if (typeof(TEntity) == typeof(Product))
            {
                var productQuery = _context.Products
                    .Where(p => p.Id == 12)
                    .OrderBy(p => p.Name)
                    .Take(5)
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .AsQueryable();

                if (!trackChanges)
                    productQuery = productQuery.AsNoTracking();

                var result = await productQuery.ToListAsync();
                return result.Cast<TEntity>();
            }

            IQueryable<TEntity> baseQuery = _context.Set<TEntity>();

            if (!trackChanges)
                baseQuery = baseQuery.AsNoTracking();

            return await baseQuery.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> spec, bool trackchanges = false)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }

        public async Task<TEntity?> GetAsync(TKey id)
        {
            if (typeof(TEntity) == typeof(Product))
            {
                return await _context.Products
                    .Where(p => p.Id == id as int?)
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .FirstOrDefaultAsync(p => p.Id == (id as int?)) as TEntity;
            }

            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?          > GetAsync(ISpecifications<TEntity, TKey> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        private IQueryable<TEntity> ApplySpecifications(ISpecifications<TEntity, TKey> spec)
        {
            return SpecificationEvaluator.GetQuery(_context.Set<TEntity>(), spec);
        }
    }
}

