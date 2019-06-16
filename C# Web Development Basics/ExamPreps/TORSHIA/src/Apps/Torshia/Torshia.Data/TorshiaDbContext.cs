using Microsoft.EntityFrameworkCore;
using Torshia.Data.Models;

namespace Torshia.Data
{
    public class TorshiaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<TaskSector> TaskSectors { get; set; }
        public DbSet<UsersTasks> UsersTasks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersTasks>()
                .HasKey(x => new { x.UserId, x.TaskId });

            modelBuilder.Entity<User>()
                .HasMany(x => x.Reports)
                .WithOne(x => x.Reporter)
                .HasForeignKey(x => x.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsersTasks>()
                .HasOne(x => x.User)
                .WithMany(x => x.UsersTasks)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<UsersTasks>()
                .HasOne(x => x.Task)
                .WithMany(x => x.UsersTasks)
                .HasForeignKey(x => x.TaskId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
