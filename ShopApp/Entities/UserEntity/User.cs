using ShopApp.Entities.AddressEntity;
using ShopApp.Entities.FavouriteEntity;
using ShopApp.Entities.OrderEntity;
using ShopApp.Entities.RootEntity;

namespace ShopApp.Entities.UserEntity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }


        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int StatusId { get; set; }
        public Root Status { get; set; }

        public List<Order> Orders { get; set; }

        public List<Favourite> Favourites { get; set; }
    }
}
