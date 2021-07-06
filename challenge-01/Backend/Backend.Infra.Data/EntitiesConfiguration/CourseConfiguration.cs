using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Data.EntitiesConfiguration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date).IsRequired();

            builder.OwnsOne(x => x.Name)
                .Property(x => x.ValueName)
                .HasColumnName("Name")
                .HasMaxLength(30)
                .IsRequired();

            builder.OwnsOne(x => x.Description)
                .Property(x => x.Message)
                .HasColumnName("Description")
                .HasMaxLength(140)
                .IsRequired();

            builder.HasOne(x => x.Module)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.ModuleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
