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
            var price = Input.GetPrice();
            var amount = Input.GetProductAmount();
            var weight = Input.GetWeight();
            var weightUnit = Input.GetWeightUnits();
            var currency = Input.GetCurrency();
            var expiryDate = Input.GetExpiryDate();

            return new FoodProductDTO(name, DTO.Enums.ProdType.Food, price, amount, weightUnit, weight, currency, expiryDate);
        }
    }
}
