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
            decimal res;
            do
            {
                Console.WriteLine("Enter product price: ");
                try
                {
                    res = Convert.ToDecimal(Console.ReadLine());
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
            while (res < 0);
            return res;
        }

        private double GetWeight()
        {
            double res;
            do
            {
                Console.WriteLine("Enter product weight: ");
                try
                {
                    res = Convert.ToDouble(Console.ReadLine());
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
            while (res < 0);

            return res;
        }

        private uint GetProductAmount()
        {
            int res;
            do
            {
                Console.WriteLine("Enter product amount: ");
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
            while (res < 0);

            return Convert.ToUInt32(res);
        }

        private Weight GetWeightUnits()
        {
            int res;
            do
            {
                Console.WriteLine("Weight unit ( 0 - Gramm, 1 - Kiloramm, 2 - Liter, 3 - Milliliter): ");
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
            while (res > 3 || res < 0);

            return (Weight)res;
        }

        private Currency GetCurrency()
        {
            int res;
            do
            {
                Console.WriteLine("Currency ( 0 - UAH, 1 - USD, 2 - EUR): ");
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

            return (Currency)res;
        }
    }
}