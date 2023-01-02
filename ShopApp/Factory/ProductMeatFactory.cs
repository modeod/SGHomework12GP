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
            try
            {
                uint res;
                do
                {
                    Console.WriteLine("Meat Type (0 - Pork, 1 - Lamb, 2 - Chicken): ");
                    string input = Console.ReadLine();
                    res = Convert.ToUInt32(input);
                }
                while (res > 2 || res < 0);
                return (MeatType)res;
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetMeatType();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                return GetMeatType();
            }
        }

        private MeatSort GetMeatSort()
        {
            try
            {
                uint res;
                do
                {
                    Console.WriteLine("Meat Sort ( 0 - First, 1 - Second): ");
                    string input = Console.ReadLine();
                    res = Convert.ToUInt32(input);
                }
                while (res > 1 || res < 0);
                return (MeatSort)res;
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetMeatSort();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                return GetMeatSort();
            }
        }
    }
}
