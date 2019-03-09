using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.EntityConfigurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.GameId);

            builder.Property(x => x.HomeTeamGoals)
                .IsRequired();

            builder.Property(x => x.AwayTeamGoals)
                .IsRequired();

            builder.Property(x => x.DateTime)
                .IsRequired();

            builder.Property(x => x.HomeTeamBetRate)
                .IsRequired();

            builder.Property(x => x.AwayTeamBetRate)
                .IsRequired();

            builder.Property(x => x.DrawBetRate)
                .IsRequired();

            builder.Property(x => x.Result)
                .IsRequired();

            builder.HasMany(x => x.PlayerStatistics)
                .WithOne(x => x.Game)
                .HasForeignKey(x => x.GameId);

            builder.HasOne(x => x.HomeTeam)
                .WithMany(x => x.HomeGames)
                .HasForeignKey(x => x.HomeTeamId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AwayTeam)
               .WithMany(x => x.AwayGames)
               .HasForeignKey(x => x.AwayTeamId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
