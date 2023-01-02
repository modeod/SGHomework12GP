using GroupProject.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.DTO
{
    public class ProductDTO
    {
        public ProductDTO(int vendorCode, string name, ProdType prodType, decimal price, uint amount, Weight weightUnit, double weight, Currency currency)
        {
            VendorCode = vendorCode;
            Name = name;
            ProdType = prodType;
            Price = price;
            Amount = amount;
            WeightUnit = weightUnit;
            Weight = weight;
            Currency = currency;
        }
        
        public int VendorCode { get; }

        public string Name { get; }

        public ProdType ProdType { get; }

        public decimal Price { get; }

        public uint Amount { get; set; }

        public Weight WeightUnit { get; }

        public double Weight { get; }

        public Currency Currency { get; }
    }
}
