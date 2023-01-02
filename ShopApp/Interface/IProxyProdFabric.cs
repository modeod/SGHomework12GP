using GroupProject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Interface
{
    public interface IProxyProdFabric : IProductFactory
    {
        public ProductDTO CreateProduct();
        public void ChooseProductType();
    }
}
