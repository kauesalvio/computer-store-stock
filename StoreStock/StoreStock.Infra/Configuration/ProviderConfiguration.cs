using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreStock.Domain.Entities;

namespace StoreStock.Infra.Configuration
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Providers");
            builder.Property(f => f.Id).UseIdentityColumn();
            builder.Property(f => f.Name).HasMaxLength(30).IsRequired();
            builder.Property(f => f.SocialContract).HasMaxLength(30).IsRequired();
            builder.Property(f => f.Cnpj).HasMaxLength(20).IsRequired();
            builder.Property(f => f.Cpf).HasMaxLength(14).IsRequired();
        }
    }
}
