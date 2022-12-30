using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ShopApp.Entities.OrderEntity
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.OrderedAt)
                .IsRequired();

            builder
                .Property(x => x.UserId)
                .IsRequired();

            builder
                .Property(x => x.StatusId)
                .IsRequired();

            builder
                .Property(x => x.AddressId)
                .IsRequired();

            builder
                .HasMany(x => x.OrderItems)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.StatusId);
        }
    }
}
