using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Interface
{
    public interface IStorageManager
    {
        public void ShowMenu();
        public void CreateProduct();
        public void DeleteProduct();
        public void ReadProduct();
        public void UpdateProduct();
    }
}
