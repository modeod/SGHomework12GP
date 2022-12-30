using Microsoft.EntityFrameworkCore;
using ShopApp.Entities.AddressEntity;
using ShopApp.Entities.FavouriteEntity;
using ShopApp.Entities.ManufactureEntity;

namespace ShopApp
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new FavouriteConfiguration());
            modelBuilder.ApplyConfiguration(new ManufactureConfiguration());
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
    }
}
