using ShopApp.Entities.OrderEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Repositories.Interfaces
{
    public interface ICRUDOrders : IUserOrder
    {
        Task<Order> DeleteOrder(Order order);
    }
}
