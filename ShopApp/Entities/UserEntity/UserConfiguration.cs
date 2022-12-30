using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entities.AddressEntity;

namespace ShopApp.Entities.UserEntity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Surname)
                .IsRequired();

            builder
                .Property(x => x.AddressId)
                .IsRequired();

            builder
                .Property(x => x.StatusId)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .IsRequired();

            builder
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.Favourites)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.StatusId);
        }
    }
}
