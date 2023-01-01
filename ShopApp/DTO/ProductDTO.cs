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
        public ProductDTO(string name, ProdType prodType, decimal price, Weight weightUnit, double weight, Currency currency)
        {
            Name = name;
            ProdType = prodType;
            Price = price;
            WeightUnit = weightUnit;
            Weight = weight;
            Currency = currency;
        }

        public string Name { get; }

        public ProdType ProdType { get; }

        public decimal Price { get; }

        public Weight WeightUnit { get; }

        public double Weight { get; }

        public Currency Currency { get; }
    }
}
