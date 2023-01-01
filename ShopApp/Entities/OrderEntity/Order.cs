using ShopApp.Entities.AddressEntity;
using ShopApp.Entities.OrderItemEntity;
using ShopApp.Entities.OrderStatusEntity;
using ShopApp.Entities.UserEntity;

namespace ShopApp.Entities.OrderEntity
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderedAt { get; set; }
        public string? Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int StatusId { get; set; }
        public OrderStatus Status { get; set; } = null!;

        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
