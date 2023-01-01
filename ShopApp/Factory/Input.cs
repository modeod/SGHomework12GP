using GroupProject.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.factory
{
    public class Input
    {
        public static string GetName()
        {
            Console.WriteLine("Enter product name: ");
            string res = Console.ReadLine();
            if (res.Length > 2) { return res; }
            return GetName();
        }

        public static ProdType GetProductType()
        {
            Console.WriteLine("Product Type ( 0 - Food, 1 - Meat, 2 - Vehicle): ");
            string input = Console.ReadLine();

            try
            {
                uint res = Convert.ToUInt32(input);
                if (res != null)
                {
                    switch (res)
                    {
                        case 0:
                            return (ProdType)0;
                            break;

                        case 1:
                            return (ProdType)1;
                            break;

                        case 2:
                            return (ProdType)2;
                            break;
                        default:
                            return GetProductType();
                    }
                }
                Console.WriteLine("Wrong number.");
                return GetProductType();
            }
            catch(FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetProductType();
            }
        }

        public static decimal GetPrice()
        {
            try
            {
                Console.WriteLine("Enter product price: ");
                decimal res = Convert.ToDecimal(Console.ReadLine());

                if (res != null && res > 0) { return res; }
                return GetPrice();
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetPrice();
            }
        }

        public static double GetWeight()
        {
            try
            {
                Console.WriteLine("Enter product weight: ");
                double res = Convert.ToDouble(Console.ReadLine());

                if (res != null && res > 0) { return res; }
                return GetWeight();
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetWeight();
            }
        }

        public static Weight GetWeightUnits()
        {
            Console.WriteLine("Weight unit ( 0 - Gramm, 1 - Kiloramm, 2 - Liter, 3 - Milliliter): ");
            string input = Console.ReadLine();

            try
            {
                uint res = Convert.ToUInt32(input);
                if (res != null)
                {
                    switch (res)
                    {
                        case 0:
                            return (Weight)0;
                            break;

                        case 1:
                            return (Weight)1;
                            break;

                        case 2:
                            return (Weight)2;
                            break;
                        
                        case 3:
                            return (Weight)3;
                            break;
                        
                        default:
                            return GetWeightUnits();
                    }
                }
                Console.WriteLine("Wrong number.");
                return GetWeightUnits();
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetWeightUnits();
            }
        }

        public static Currency GetCurrency()
        {
            Console.WriteLine("Currency ( 0 - UAH, 1 - USD, 2 - EUR): ");
            string input = Console.ReadLine();

            try
            {
                uint res = Convert.ToUInt32(input);
                if (res != null)
                {
                    switch (res)
                    {
                        case 0:
                            return (Currency)0;
                            break;

                        case 1:
                            return (Currency)1;
                            break;

                        case 2:
                            return (Currency)2;
                            break;
                        default:
                            return GetCurrency();
                    }
                }
                return GetCurrency();
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetCurrency();
            }
        }

        public static DateOnly GetExpiryDate()
        {
            try
            {
                Console.WriteLine("Enter expiry date (Format: DD.MM.YYYY): ");
                string format = "dd.MM.yyyy";
                string input = Console.ReadLine();

                DateOnly res = DateOnly.ParseExact(input, format, CultureInfo.InvariantCulture);

                if (res != null && res > DateOnly.FromDateTime(DateTime.Now.Date)) { return res; }
                Console.WriteLine("Incorrect inputed date.");
                return GetExpiryDate();
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetExpiryDate();
            }
        }

        public static MeatType GetMeatType()
        {
            Console.WriteLine("Meat Type ( 0 - Pork, 1 - Lamb, 2 - Chicken): ");
            string input = Console.ReadLine();

            try
            {
                uint res = Convert.ToUInt32(input);
                if (res != null)
                {
                    switch (res)
                    {
                        case 0:
                            return (MeatType)0;
                            break;

                        case 1:
                            return (MeatType)1;
                            break;

                        case 2:
                            return (MeatType)2;
                            break;
                        default:
                            return GetMeatType();
                    }
                }
                Console.WriteLine("Wrong number.");
                return GetMeatType();
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetMeatType();
            }
        }

        public static MeatSort GetMeatSort()
        {
            Console.WriteLine("Meat sort ( 0 - First, 1 - Second): ");
            string input = Console.ReadLine();

            try
            {
                uint res = Convert.ToUInt32(input);
                if (res != null)
                {
                    switch (res)
                    {
                        case 0:
                            return (MeatSort)0;
                            break;

                        case 1:
                            return (MeatSort)1;
                            break;

                        default:
                            return GetMeatSort();
                    }
                }
                Console.WriteLine("Wrong number.");
                return GetMeatSort();
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return GetMeatSort();
            }
        }

        public static string GetDescription()
        {
            return Console.ReadLine();
        }
    }
}
