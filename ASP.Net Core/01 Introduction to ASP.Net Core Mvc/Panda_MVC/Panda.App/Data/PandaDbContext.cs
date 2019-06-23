using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Panda.App.Domains;

namespace Panda.App.Data
{
    public class PandaDbContext : IdentityDbContext
    {
     
        //public DbSet<PandaUser> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

  

        
        public PandaDbContext(DbContextOptions<PandaDbContext> options)
            : base(options)
        {
              
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PandaUser>()
                .HasMany(x => x.Packages)
                .WithOne(x => x.Recipient)
                .HasForeignKey(x => x.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PandaUser>()
               .HasMany(x => x.Receipts)
               .WithOne(x => x.Recipient)
               .HasForeignKey(x => x.RecipientId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Package>()
                .HasOne(x => x.Receipt)
                .WithOne(x => x.Package)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
