namespace SoftJail.Data
{
	using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
	{
		public SoftJailDbContext()
		{
		}

		public SoftJailDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Cell> Cells { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }
        public DbSet<Prisoner> Prisoners { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.Entity<OfficerPrisoner>()
                .HasKey(x => new { x.OfficerId, x.PrisonerId });

            builder.Entity<OfficerPrisoner>()
               .HasOne(bc => bc.Prisoner)
               .WithMany(b => b.PrisonerOfficers)
               .HasForeignKey(bc => bc.PrisonerId);

            builder.Entity<OfficerPrisoner>()
              .HasOne(bc => bc.Officer)
              .WithMany(b => b.OfficerPrisoners)
              .HasForeignKey(bc => bc.OfficerId);
        }
	}
}