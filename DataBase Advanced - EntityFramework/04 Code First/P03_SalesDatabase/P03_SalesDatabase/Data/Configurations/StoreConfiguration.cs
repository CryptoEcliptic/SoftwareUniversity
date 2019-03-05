using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(x => x.StoreId);

            builder.Property(x => x.Name)
                .IsUnicode()
                .HasMaxLength(80);

            builder.HasMany(x => x.Sales)
                .WithOne(x => x.Store)
                .HasForeignKey(x => x.StoreId);

        }
    }
}