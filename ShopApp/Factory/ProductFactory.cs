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
            var price = GetPrice();
            var amount = GetProductAmount();
            var weight = GetWeight();
            var weightUnit = GetWeightUnits();
            var currency = GetCurrency();


            return new ProductDTO(0, name, DTO.Enums.ProdType.Product, price, amount, weightUnit, weight, currency);
        }

        private string GetName()
        {
            Console.WriteLine("Enter product name: ");
            string res = Console.ReadLine();
            if (res.Length > 2) { return res; }
            return GetName();
        }

        private decimal GetPrice()
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

        private double GetWeight()
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

        private uint GetProductAmount()
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

        private Weight GetWeightUnits()
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
                while (res > 3 || res < 0);
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

        private Currency GetCurrency()
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
                while (res > 2 || res < 0);
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
    }
}