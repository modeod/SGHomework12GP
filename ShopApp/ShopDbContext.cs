using Microsoft.EntityFrameworkCore;
using ShopApp.Entities.AddressEntity;
using ShopApp.Entities.FavouriteEntity;
using ShopApp.Entities.ManufactureEntity;
using ShopApp.Entities.OrderEntity;
using ShopApp.Entities.OrderItemEntity;
using ShopApp.Entities.OrderStatusEntity;
using ShopApp.Entities.ProductEntity;
using ShopApp.Entities.RootEntity;
using ShopApp.Entities.UserEntity;

namespace ShopApp
{
    public class ShopDbContext : DbContext
    {
        //public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new FavouriteConfiguration());
            modelBuilder.ApplyConfiguration(new ManufactureConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new RootConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Favourite> Favourites { get; set; } = null!;
        public DbSet<Manufacter> Manufactures { get; set; } = null!; 
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Root> Roots { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
