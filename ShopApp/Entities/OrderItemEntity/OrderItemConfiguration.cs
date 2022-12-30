using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopApp.Entities.OrderItemEntity
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Amount)
                .IsRequired();

            builder
                .Property(x => x.PriceWithSale)
                .IsRequired();

            builder
                .Property(x => x.OrderId)
                .IsRequired();

            builder
                .Property(x => x.ProductVendorCode)
                .IsRequired();

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.ProductVendorCode);

        }
    }
}
