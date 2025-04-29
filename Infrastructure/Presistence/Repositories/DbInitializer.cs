using Domain.Contracts;
using Domain.Models;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using Presistence.Identity;
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
        private readonly StoreIdentityDbContext _identityDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(
            StoreDbContext context,
            StoreIdentityDbContext identityDbContext,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _identityDbContext = identityDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
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

        public async Task InitializeIdentityAsync()
        {
            // Create Database If it doesn't Exists && Apply To Any Pending Migrations
            if (_identityDbContext.Database.GetPendingMigrations().Any())
            {
                await _identityDbContext.Database.MigrateAsync();
            }
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(role: new IdentityRole()
                {
                    Name = "Admin"
                });
                await _roleManager.CreateAsync(role: new IdentityRole()
                {
                    Name = "SuperAdmin"
                });
            }

            // Seeding
            if (!_userManager.Users.Any())
            {
                var superAdminUser = new AppUser()
                {
                    DisplayName = "Super Admin",
                    Email = "SuperAdmin@gmail.com",
                    UserName = "SuperAdmin",
                    PhoneNumber = "0123456789"
                };

                var adminUser = new AppUser()
                {
                    DisplayName = "Admin",
                    Email = "Admin@gmail.com",
                    UserName = "Admin",
                    PhoneNumber = "0123456789"
                };

                var superAdminResult = await _userManager.CreateAsync(superAdminUser, "Pa$$wOrd");
                var adminResult = await _userManager.CreateAsync(adminUser, "Pa$$wOrd");

                if (superAdminResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(superAdminUser, "SuperAdmin");
                }

                if (adminResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

        }
    }
    }
