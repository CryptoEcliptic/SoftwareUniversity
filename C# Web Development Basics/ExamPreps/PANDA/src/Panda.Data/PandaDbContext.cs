using Microsoft.EntityFrameworkCore;
using Panda.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Data
{
    public class PandaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Package> Packages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                 .HasMany(x => x.Packages)
                 .WithOne(x => x.Recipient)
                 .HasForeignKey(x => x.RecipientId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Receipts)
                .WithOne(x => x.Recipient)
                .HasForeignKey(x => x.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
