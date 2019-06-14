using Microsoft.EntityFrameworkCore;
using Musaca.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musaca.Data
{
    public class MusacaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrdersProducts> OrdersProducts { get; set; }
       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdersProducts>()
           .HasKey(t => new { t.OrderId, t.ProductId });

            modelBuilder.Entity<OrdersProducts>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrdersProducts)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrdersProducts>()
               .HasOne(x => x.Product)
               .WithMany(x => x.OrdersProducts)
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
}
