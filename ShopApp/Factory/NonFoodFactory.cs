using GroupProject.DTO;
using ShopApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.factory
{
    public class NonFoodFactory : ProductFactory
    {
        public new ProductDTO CreateProduct()
        {
            var product = base.CreateProduct();
            var description = GetDescription();

            return new NonFoodProductDTO(0, product.Name, DTO.Enums.ProdType.Vehicle, product.Price, product.Amount, product.WeightUnit, product.Weight, product.Currency, description);
        }
        public static string GetDescription()
        {
            return Console.ReadLine() ?? "";
        }
    }
}
