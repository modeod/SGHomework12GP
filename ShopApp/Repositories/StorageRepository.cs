using Microsoft.EntityFrameworkCore;
using ShopApp.Entities.ProductEntity;
using ShopApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Repositories
{
    internal class StorageRepository : ICRUDStorage
    {
        private ShopDbContext _dbContext;
        public StorageRepository(ShopDbContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> CreateProduct(Product product)
        {
            try
            {
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            try
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<Product?> FindProductsById(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<List<Product>> ReadProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            try
            {
                _dbContext.Entry(product).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
    }
}
