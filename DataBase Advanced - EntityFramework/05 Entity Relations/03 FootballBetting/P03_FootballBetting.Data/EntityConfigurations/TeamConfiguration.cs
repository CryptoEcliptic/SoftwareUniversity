using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.EntityConfigurations
{
    class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.TeamId);

            builder.Property(x => x.Name)
                .HasMaxLength(60)
                .IsUnicode()
                .IsRequired();

            builder.Property(t => t.LogoUrl)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(t => t.Initials)
                 .IsRequired()
                 .IsUnicode(false)
                 .HasMaxLength(3)
                 .HasDefaultValueSql("CHAR(3)");

            builder.HasOne(x => x.Town)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.TownId);
            
            builder.HasMany(x => x.Players)
                .WithOne(x => x.Team)
                .HasForeignKey(x => x.TeamId);
        }
    }
}
