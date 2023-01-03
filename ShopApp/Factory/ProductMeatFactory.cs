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
    public class ProductMeatFactory : ProductFoodFactory
    {
        public new MeatDTO CreateProduct()
        {
            var foodProduct = base.CreateProduct();
            var meatType = GetMeatType();
            var meatTSort = GetMeatSort();

            return new MeatDTO(0, foodProduct.Name, DTO.Enums.ProdType.Meat, foodProduct.Price, foodProduct.Amount, foodProduct.WeightUnit, foodProduct.Weight, foodProduct.Currency, foodProduct.ExpiryDate, meatTSort, meatType);
        }


        private MeatType GetMeatType()
        {
            int res;
            do
            {
                Console.WriteLine("Meat Type (0 - Pork, 1 - Lamb, 2 - Chicken): ");
                try
                {
                    res = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect formatting.");
                    res = -1;
                    continue;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                    res = -1;
                    continue;
                }
            }
            while (res > 2 || res < 0);
            return (MeatType)res;
        }

        private MeatSort GetMeatSort()
        {
            int res;
            do
            {
                Console.WriteLine("Meat Sort ( 0 - First, 1 - Second): ");
                try
                {
                    res = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect formatting.");
                    res = -1;
                    continue;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                    res = -1;
                    continue;
                }
            }
            while (res > 1 || res < 0);

            return (MeatSort)res;
        }
    }
}