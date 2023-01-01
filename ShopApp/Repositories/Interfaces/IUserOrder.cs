using ShopApp.Entities.OrderEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Repositories.Interfaces
{
    internal interface IUserOrder
    {
        Task<List<Order>> GetAll();
        Task<Order?> GetById(int id);
        Task<Order> CreateOrder(Order order);
        Task<Order> UpdateOrder(Order order);
    }
}
