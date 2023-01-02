using ShopApp.Entities.ProductEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Repositories.Interfaces
{
    public interface IReadStorage
    {
        Task<List<Product>> ReadProducts();
        Task<Product?> FindProductsById(int id);
    }
}
