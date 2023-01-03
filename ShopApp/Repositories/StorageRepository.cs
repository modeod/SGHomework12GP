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
    public class StorageRepository : ICRUDStorage
    {
        private readonly ShopDbContext _dbContext;
        public StorageRepository(ShopDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            if (product is null)
            {
                throw new NullReferenceException("Product can`t be null");
            }
            try
            {
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return _dbContext.Products.First(p => p.VendorCode == product.VendorCode);
            }
            catch (DbUpdateException)
            {
                throw new ArgumentException("Couldn`t create product");
            }
        }

        public async Task<Product> DeleteProduct(int vendorCode)
        {
            var product = await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.VendorCode == vendorCode);
            if (product == null)
            {
                throw new ArgumentException("Wrong id");
            }
            try
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return product;
            }
            catch (DbUpdateException)
            {
                throw new Exception("Couldn`t delete order");
            }
        }

        public async Task<Product?> FindProductsById(int id)
        {
            return await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(prod => prod.VendorCode == id);
        }

        public async Task<List<Product>> ReadProducts()
        {
            return await _dbContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            if (product is null)
            {
                throw new NullReferenceException("Product can`t be null");
            }
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry(product).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return _dbContext.Products.First(p => p.VendorCode == p.VendorCode);
            }
            catch (DbUpdateException)
            {
                throw new ArgumentException("Couldn`t update order");
            }
        }
    }
}
