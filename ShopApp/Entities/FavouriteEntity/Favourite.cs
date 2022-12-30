using ShopApp.Entities.OrderItemEntity;
using ShopApp.Entities.ProductEntity;
using ShopApp.Entities.UserEntity;

namespace ShopApp.Entities.FavouriteEntity
{
    public class Favourite
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductVendorCode { get; set; }
        public Product Product { get; set; }
    }
}
