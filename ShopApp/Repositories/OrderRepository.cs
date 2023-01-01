using Microsoft.EntityFrameworkCore;
using ShopApp.Entities.OrderEntity;
using ShopApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Repositories
{
    internal class OrderRepository : ICRUDOrders
    {
        private ShopDbContext _dbContext;
        public OrderRepository(ShopDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            try
            {
                await _dbContext.Orders.AddAsync(order);
                await _dbContext.SaveChangesAsync();
                return await _dbContext.Orders.FirstAsync(o => o.Id == order.Id);
            }
            catch (DbUpdateException)
            {
                throw new ArgumentException("Couldn`t create order");
            }
        }

        public async Task<Order> DeleteOrder(Order order)
        {
            try
            {
                _dbContext.Remove(order);
                await _dbContext.SaveChangesAsync();
                return order;
            }
            catch (DbUpdateException)
            {
                throw new ArgumentException("Couldn`t delete order");
            }
        }

        public async Task<List<Order>> GetAll()
        {
            return await _dbContext.Orders.ToListAsync();
        }
        public async Task<Order?> GetById(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            try
            {
                _dbContext.Entry(order).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return await _dbContext.Orders.FirstAsync(o => o.Id == order.Id);
            }
            catch (DbUpdateException)
            {
                throw new ArgumentException("Couldn`t update order");
            }
        }
    }
}
