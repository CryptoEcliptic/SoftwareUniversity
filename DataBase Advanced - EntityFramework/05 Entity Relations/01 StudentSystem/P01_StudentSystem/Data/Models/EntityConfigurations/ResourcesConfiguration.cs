namespace P01_StudentSystem.Data.Models.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ResourcesConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(x => x.ResourceId);

            builder.Property(x => x.Name)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Url)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(x => x.ResourceType)
                .IsRequired();
        }
    }
}
