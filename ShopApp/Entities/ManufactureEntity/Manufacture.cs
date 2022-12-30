using ShopApp.Entities.AddressEntity;
using ShopApp.Entities.ProductEntity;

namespace ShopApp.Entities.ManufactureEntity
{
    public class Manufacture
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
