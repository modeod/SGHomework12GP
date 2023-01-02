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
            var name = GetName();
            var productType = GetProductType();
            var price = GetPrice();
            var amount = GetProductAmount();
            var weight = GetWeight();
            var weightUnit = GetWeightUnits();
            var currency = GetCurrency();

            return new ProductDTO(name, productType, price, amount, weightUnit, weight, currency);
        }

        public static string GetName()
        {
            Console.WriteLine("Enter product name: ");
            string res = Console.ReadLine();
            if (res.Length > 2) { return res; }
            return GetName();
        }

        public static decimal GetPrice()
        {
            try
            {
                decimal res;
                do
                {
                    Console.WriteLine("Enter product price: ");
                    res = Convert.ToDecimal(Console.ReadLine());
                }
                while (res < 0);
                return res;
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetPrice();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                return GetPrice();
            }
        }

        public static double GetWeight()
        {
            try
            {
                double res;
                do
                {
                    Console.WriteLine("Enter product weight: ");
                    res = Convert.ToDouble(Console.ReadLine());
                }
                while (res < 0);
                return res;
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetWeight();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                return GetWeight();
            }
        }

        public static uint GetProductAmount()
        {
            try
            {
                Console.WriteLine("Enter product amount: ");
                uint res = Convert.ToUInt32(Console.ReadLine());
                return res;
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetProductAmount();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                return GetProductAmount();
            }
        }

        public static Weight GetWeightUnits()
        {
            try
            {
                uint res;
                do
                {
                    Console.WriteLine("Weight unit ( 0 - Gramm, 1 - Kiloramm, 2 - Liter, 3 - Milliliter): ");
                    string input = Console.ReadLine();
                    res = Convert.ToUInt32(input);
                }
                while (res > 3 && res < 0);
                return (Weight)res;
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetWeightUnits();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                return GetWeightUnits();
            }
        }

        public static Currency GetCurrency()
        {
            try
            {
                uint res;
                do
                {
                    Console.WriteLine("Currency ( 0 - UAH, 1 - USD, 2 - EUR): ");
                    string input = Console.ReadLine();
                    res = Convert.ToUInt32(input);
                }
                while (res > 2 && res < 0);
                return (Currency)res;
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetCurrency();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                return GetCurrency();
            }
        }

        public static ProdType GetProductType()
        {
            try
            {
                uint res;
                do
                {
                    Console.WriteLine("Product Type ( 0 - Food, 1 - Meat, 2 - Vehicle): ");
                    string input = Console.ReadLine();
                    res = Convert.ToUInt32(input);
                }
                while (res > 3 && res < 0);
                return (ProdType)res;
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetProductType();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                return GetProductType();
            }
        }
    }
}
