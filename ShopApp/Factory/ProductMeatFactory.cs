using GroupProject.DTO;
using ShopApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.factory
{
    public class ProductMeatFactory : IProductFactory
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
            var meatType = Input.GetMeatType();
            var meatTSort = Input.GetMeatSort();

            return new MeatDTO(name, productType, price, weightUnit, weight, currency, expiryDate, meatTSort, meatType);
        }
    }
}
