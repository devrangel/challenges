using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Data.EntitiesConfiguration
{
    public class ModuleConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name)
                .Property(x => x.ValueName)
                .HasColumnName("Name")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
