using GroupProject.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.DTO
{
    public class NonFoodProductDTO : ProductDTO
    {
        public NonFoodProductDTO(int vendorCode, string name, ProdType prodType, decimal price, uint amount, Weight weightUnit, double weight, Currency currency, string description)
                                    : base(vendorCode, name, prodType, price, amount, weightUnit, weight, currency)
        {
            Description = description;
        }

        public string Description { get; }
    }
}
