﻿using Microsoft.EntityFrameworkCore;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(P => P.ProductBrand)
                  .WithMany()
                  .HasForeignKey(P => P.BrandId);

            builder.HasOne(P => P.ProductType)
                 .WithMany()
                 .HasForeignKey(P => P.TypeId);

            builder.Property(P => P.Price)
                .HasColumnType("decimal(18,2)");
        }
        
    }
}
