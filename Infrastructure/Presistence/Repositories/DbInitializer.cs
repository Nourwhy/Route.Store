using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class DbInitializer : IDbIntializer
    {
        private readonly StoreDbContext _context;

        public DbInitializer(StoreDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
        
            if (_context.Database.GetPendingMigrations().Any())
            {
                await _context.Database.MigrateAsync();
            }

          
            if (!_context.ProductTypes.Any())
            {
                var typesFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\Infrastructure\Presistence\Data\Seeding\types.json");
                if (File.Exists(typesFilePath))
                {
                    var typesData = await File.ReadAllTextAsync(typesFilePath);
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    if (types is not null && types.Any())
                    {
                        await _context.ProductTypes.AddRangeAsync(types);
                    }
                }
            }

    
            if (!_context.ProductBrands.Any())
            {
                var brandFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\Infrastructure\Presistence\Data\Seeding\brands.json");
                if (File.Exists(brandFilePath))
                {
                    var brandData = await File.ReadAllTextAsync(brandFilePath);
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                    if (brands is not null && brands.Any())
                    {
                        await _context.ProductBrands.AddRangeAsync(brands);
                    }
                }
            }

            if (!_context.Products.Any())
            {
                var productsFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\Infrastructure\Presistence\Data\Seeding\products.json");
                if (File.Exists(productsFilePath))
                {
                    var productsData = await File.ReadAllTextAsync(productsFilePath);
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    if (products is not null && products.Any())
                    {
                        await _context.Products.AddRangeAsync(products);
                    }
                }
            }

            if (_context.ChangeTracker.HasChanges())
            {
                await _context.SaveChangesAsync();
            }
        }
    }
}
