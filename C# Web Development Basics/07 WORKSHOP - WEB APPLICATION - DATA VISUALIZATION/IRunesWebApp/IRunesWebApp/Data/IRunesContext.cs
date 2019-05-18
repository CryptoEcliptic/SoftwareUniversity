namespace IRunesWebApp.Data
{
    using IRunesWebApp.Models;
    using Microsoft.EntityFrameworkCore;

    public class IRunesContext : DbContext
    {
        public IRunesContext() { }

        public IRunesContext(DbContextOptions<IRunesContext> options)
           : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString)
                    .UseLazyLoadingProxies();

            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
