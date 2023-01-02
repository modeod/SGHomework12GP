using GroupProject.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.DTO
{
    public class FoodProductDTO : ProductDTO
    {
        public FoodProductDTO(int vendorCode, string name, ProdType prodType, decimal price, uint amount, Weight weightUnit, double weight, Currency currency, DateTime expiryDate) 
                                    : base(vendorCode, name, prodType, price, amount, weightUnit, weight, currency)
        {
            ExpiryDate = expiryDate;
        }

        public DateTime ExpiryDate { get; }
    }
}
