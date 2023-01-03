using ShopApp.Entities.AddressEntity;
using ShopApp.Entities.FavouriteEntity;
using ShopApp.Entities.OrderEntity;
using ShopApp.Entities.RootEntity;

namespace ShopApp.Entities.UserEntity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;

        public int StatusId { get; set; }
        public Root Status { get; set; } = null!;

        public List<Order> Orders { get; set; } = new List<Order>();

        public List<Favourite> Favourites { get; set; } = new List<Favourite>();
    }
}
