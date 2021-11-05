using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreStock.Domain.Entities;

namespace StoreStock.Infra.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(f => f.Id).UseIdentityColumn();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(30).IsRequired();
        }
    }
}
