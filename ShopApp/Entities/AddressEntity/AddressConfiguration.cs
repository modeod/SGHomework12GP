using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopApp.Entities.AddressEntity
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Country)
                .IsRequired();

            builder
                .Property(x => x.Region)
                .IsRequired();

            builder
                .Property(x => x.City)
                .IsRequired();

            builder
                .Property(x => x.Street)
                .IsRequired();

            builder
                .Property(x => x.House)
                .IsRequired();
        }
    }
}
