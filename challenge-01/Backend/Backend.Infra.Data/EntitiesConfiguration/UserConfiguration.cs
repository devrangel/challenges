using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Data.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Username)
                .Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(20)
                .IsRequired();

            builder.OwnsOne(x => x.Username)
                .Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(20)
                .IsRequired();

            builder.OwnsOne(x => x.Email)
                .Property(x => x.Address)
                .HasMaxLength(50)
                .HasColumnName("Email")
                .IsRequired();

            builder.OwnsOne(x => x.Password)
                .Property(x => x.KeyPassword)
                .HasMaxLength(50)
                .HasColumnName("Password")
                .IsRequired();

            builder.OwnsOne(x => x.Role)
                .Property(x => x.RoleValue)
                .HasMaxLength(15)
                .HasColumnName("Role")
                .IsRequired();
        }
    }
}
