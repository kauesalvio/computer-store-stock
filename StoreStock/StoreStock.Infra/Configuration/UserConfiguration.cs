using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreStock.Domain.Entities;

namespace StoreStock.Infra.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuários");
            builder.Property(u => u.Email).UseIdentityColumn().IsRequired();
            builder.Property(u => u.Password).HasMaxLength(30).IsRequired();
        }
    }
}
