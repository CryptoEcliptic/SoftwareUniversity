using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.Property(x => x.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Name)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(x => x.Balance)
              .IsRequired();

            builder.HasMany(x => x.Bets)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
