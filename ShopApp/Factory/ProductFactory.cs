using GroupProject.DTO;
using GroupProject.DTO.Enums;
using ShopApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.factory
{
    public class ProductFactory : IProductFactory
    {
        public ProductDTO CreateProduct()
        {
            var name = Input.GetName();
            var productType = Input.GetProductType();
            var price = Input.GetPrice();
            var amount = Input.GetProductAmount();
            var weight = Input.GetWeight();
            var weightUnit = Input.GetWeightUnits();
            var currency = Input.GetCurrency();

            return new ProductDTO(name, productType, price, amount, weightUnit, weight, currency);
        }
    }
}
