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
        public MeatDTO(string name, ProdType prodType, decimal price, Weight weightUnit, double weight, Currency currency, DateOnly expiryDate, MeatSort meatSort, MeatType meatType) 
                            : base(name, prodType, price, weightUnit, weight, currency, expiryDate)
        {
            MeatSort = meatSort;
            MeatType = meatType;
        }

        public MeatSort MeatSort { get; }

        public MeatType MeatType { get; }
    }
}
