using ShopApp.Entities.OrderEntity;

namespace ShopApp.Interface
{
    public interface IOrderManager
    {
        Task CreateOrder();
        Task ReadOrders();
        Task UpdateOrder();
        Task DeleteOrder();
        Task ShowMenu();
    }
}