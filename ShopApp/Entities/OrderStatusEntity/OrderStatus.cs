using ShopApp.Entities.OrderEntity;

namespace ShopApp.Entities.OrderStatusEntity
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
