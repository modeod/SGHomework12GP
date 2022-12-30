using ShopApp.Entities.AddressEntity;
using ShopApp.Entities.ProductEntity;

namespace ShopApp.Entities.ManufactureEntity
{
    public class Manufacter
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
