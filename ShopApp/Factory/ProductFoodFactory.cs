using GroupProject.DTO;
using ShopApp.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.factory
{
    public class ProductFoodFactory : ProductFactory
    {
        public new FoodProductDTO CreateProduct()
        {
            var product = base.CreateProduct();
            var expiryDate = GetExpiryDate();

            return new FoodProductDTO(0, product.Name, DTO.Enums.ProdType.Food, product.Price, product.Amount, product.WeightUnit, product.Weight, product.Currency, expiryDate);
        }


        private DateTime GetExpiryDate()
        {
            DateTime res;
            do
            {
                Console.WriteLine("Enter expiry date (Format: DD.MM.YYYY HH:MM:SS in 24-hour clock time): ");
                string input = Console.ReadLine();
                if (!DateTime.TryParse(input, out res)) { continue; }
            }
            while (res <= DateTime.Now.Date);
            return res;
        }
    }
}