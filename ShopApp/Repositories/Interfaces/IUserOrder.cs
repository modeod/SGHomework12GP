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
        Task<bool> CreateOrder(Order order);
        Task<bool> UpdateOrder(Order order);
    }
}
