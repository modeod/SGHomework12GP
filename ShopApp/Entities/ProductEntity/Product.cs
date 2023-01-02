using GroupProject.DTO.Enums;
using ShopApp.Entities.FavouriteEntity;
using ShopApp.Entities.OrderItemEntity;

namespace ShopApp.Entities.ProductEntity
{
    public class Product
    {
        public int VendorCode { get; set; }
        public decimal Price { get; set; }
        public ProdType ProdType { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public uint Amount { get; set; }
        public Weight WeightUnit { get; set; }
        public double Weight { get; set; }
        public MeatSort? MeatSort { get; set; }
        public MeatType? MeatType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Currency Currency { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
    }
}