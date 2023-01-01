using GroupProject.DTO;
using ShopApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.factory
{
    public class ProductFoodFactory : IProductFactory
    {
        public ProductDTO CreateProduct()
        {
            var name = Input.GetName();
            var productType = Input.GetProductType();
            var price = Input.GetPrice();
            var weight = Input.GetWeight();
            var weightUnit = Input.GetWeightUnits();
            var currency = Input.GetCurrency();
            var expiryDate = Input.GetExpiryDate();

            return new FoodProductDTO(name, productType, price, weightUnit, weight, currency, expiryDate);
        }
    }
}
