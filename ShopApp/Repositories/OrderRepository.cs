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
        public async Task<bool> CreateOrder(Order order)
        {
            try
            {
                await _dbContext.Orders.AddAsync(order);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrder(Order order)
        {
            try
            {
                _dbContext.Remove(order);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
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

        public async Task<bool> UpdateOrder(Order order)
        {
            try
            {
                _dbContext.Entry(order).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
