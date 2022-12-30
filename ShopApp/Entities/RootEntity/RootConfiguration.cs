using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopApp.Entities.RootEntity
{
    public class RootConfiguration : IEntityTypeConfiguration<Root>
    {
        public void Configure(EntityTypeBuilder<Root> builder)
        {
            builder
                .HasKey(x => x.Id);
        }
    }
}
