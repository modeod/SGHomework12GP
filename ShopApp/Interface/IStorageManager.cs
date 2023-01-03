using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Interface
{
    public interface IStorageManager
    {
        public  Task ShowMenu();
        public  Task CreateProduct();
        public  Task DeleteProduct();
        public  Task ReadProduct();
        public  Task UpdateProduct();
        public  Task FindProductsById();
    }
}
