using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreStock.Domain.Entities;

namespace StoreStock.Infra.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.Property(p => p.Id).UseIdentityColumn().IsRequired();
            builder.Property(p => p.Name).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Category).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Unity).HasDefaultValue(1).IsRequired();
            builder.Property(p => p.Provider).IsRequired();

            //builder.HasOne(p => p.Provider).WithMany().HasForeignKey(p => p.ProviderId).IsRequired();
        }
    }
}
