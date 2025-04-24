using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Identity
{
    // CLR
    public class StoreIdentityDbContext : IdentityDbContext<AppUser>
    {
        public StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options)
            : base(options)
        {
        }

        // Temporary constructor for migrations only
        public StoreIdentityDbContext()
            : base(new DbContextOptionsBuilder<StoreIdentityDbContext>()
                .UseSqlServer("Server=NOURSLAPTOP325\\MSSQLSERVER03;Database=RouteStore;Trusted_Connection=True;TrustServerCertificate=True;") // Hard-code your connection string temporarily
                .Options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Address>().ToTable("Addresses");
        }
    }

}
