using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.DoctorId);

            builder.Property(d => d.Name)
                .IsUnicode()
                .HasMaxLength(100);

            builder.Property(x => x.Specialty)
                .IsUnicode()
                .HasMaxLength(100);

            builder.HasMany(x => x.Visitations)
               .WithOne(x => x.Doctor)
               .HasForeignKey(x => x.DoctorId);
        }
    }
}
