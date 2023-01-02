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

            return new FoodProductDTO(product.Name, DTO.Enums.ProdType.Food, product.Price, product.Amount, product.WeightUnit, product.Weight, product.Currency, expiryDate);
        }


        public static DateOnly GetExpiryDate()
        {
            try
            {
                string format = "dd.MM.yyyy";
                DateOnly res;
                do
                {
                    Console.WriteLine("Enter expiry date (Format: DD.MM.YYYY): ");
                    string input = Console.ReadLine();
                    res = DateOnly.ParseExact(input, format, CultureInfo.InvariantCulture);
                }
                while (res <= DateOnly.FromDateTime(DateTime.Now.Date));
                return res;
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetExpiryDate();
            }
        }
    }
}
