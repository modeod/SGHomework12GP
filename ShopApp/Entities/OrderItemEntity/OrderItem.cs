using ShopApp.Entities.FavouriteEntity;
using ShopApp.Entities.OrderEntity;
using ShopApp.Entities.ProductEntity;

namespace ShopApp.Entities.OrderItemEntity
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal PriceWithSale { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int ProductVendorCode { get; set; }
        public Product Product { get; set; } = null!;
    }
}
