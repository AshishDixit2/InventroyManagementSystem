
using InventoryManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);
            builder.Property(x => x.Measurement).HasMaxLength(256);
            builder.HasOne(x => x.ProductCategory).WithOne().HasForeignKey<Product>(p => p.CategoryId);
        }
    }
}