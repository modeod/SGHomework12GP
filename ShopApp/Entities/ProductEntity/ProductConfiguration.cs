using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopApp.Entities.ProductEntity
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(x => x.VendorCode);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.ManufacterId)
                .IsRequired();

            builder
                .HasOne(x => x.Manufacter)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ManufacterId);
        }
    }
}
