namespace P01_StudentSystem.Data.Models.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(x => x.HomeworkId);

            builder.Property(x => x.Content)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(x => x.ContentType)
                .IsRequired();

            builder.Property(x => x.SubmissionTime)
                .IsRequired();

        }
    }
}
