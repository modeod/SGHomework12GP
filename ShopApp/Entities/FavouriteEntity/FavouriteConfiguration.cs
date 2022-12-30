using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopApp.Entities.FavouriteEntity
{
    public class FavouriteConfiguration : IEntityTypeConfiguration<Favourite>
    {
        public void Configure(EntityTypeBuilder<Favourite> builder)
        {
            builder
                .HasKey(x => new { x.UserId, x.ProductVendorCode });

            builder
                .Property(x => x.UserId)
                .IsRequired();

            builder
                .Property(x => x.ProductVendorCode)
                .IsRequired();

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.Favourites)
                .HasForeignKey(x => x.ProductVendorCode);
        }
    }
}
