using GroupProject.DTO;
using ShopApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.factory
{
    public class NonFoodFactory : IProductFactory
    {
        public ProductDTO CreateProduct()
        {
            var name = Input.GetName();
            var price = Input.GetPrice();
            var amount = Input.GetProductAmount();
            var weight = Input.GetWeight();
            var weightUnit = Input.GetWeightUnits();
            var currency = Input.GetCurrency();
            var description = Input.GetDescription();

            return new NonFoodProductDTO(name, DTO.Enums.ProdType.Vehicle, price, amount, weightUnit, weight, currency, description);
        }
    }
}
