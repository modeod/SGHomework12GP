using ShopApp.Entities.ProductEntity;

namespace ShopApp.DTO
{
    public class OrderDTO
    {
        public List<Product> Products { get; set; } = null!;
        public string? Description { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
