using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopApp.Entities.ManufactureEntity
{
    public class ManufactureConfiguration : IEntityTypeConfiguration<Manufacter>
    {
        public void Configure(EntityTypeBuilder<Manufacter> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Title)
                .IsRequired();

            builder
                .Property(x => x.AddressId)
                .IsRequired();
        }
    }
}
