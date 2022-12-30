using ShopApp.Entities.FavouriteEntity;
using ShopApp.Entities.ManufactureEntity;
using ShopApp.Entities.OrderItemEntity;

namespace ShopApp.Entities.ProductEntity
{
    public class Product
    {
        public int VendorCode { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; }


        public int ManufacterId { get; set; }
        public Manufacture Manufacturer { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        
        public List<Favourite> Favourites { get; set; }
    }
}
