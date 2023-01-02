using GroupProject.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.DTO
{
    public class MeatDTO : FoodProductDTO
    {
        public MeatDTO(int vendorCode, string name, ProdType prodType, decimal price, uint amount, Weight weightUnit, double weight, Currency currency, DateTime expiryDate, MeatSort meatSort, MeatType meatType) 
                            : base(vendorCode, name, prodType, price, amount, weightUnit, weight, currency, expiryDate)
        {
            MeatSort = meatSort;
            MeatType = meatType;
        }

        public MeatSort MeatSort { get; }

        public MeatType MeatType { get; }
    }
}
