using ShopApp.Entities.ManufactureEntity;
using ShopApp.Entities.OrderEntity;
using ShopApp.Entities.UserEntity;

namespace ShopApp.Entities.AddressEntity
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int House { get; set; }
        public int? Flat { get; set; }

        public List<User> Users { get; set; } = new List<User>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Manufacter> Manufacters { get; set; } = new List<Manufacter>();
    }
}
