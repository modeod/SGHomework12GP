using ShopApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.PaymentService
{
    public class CreditCardPay : IPayment
    {
        public bool Pay(decimal _amount)
        {
            Console.WriteLine("Оплата кредиткою");
            return true;
        }
    }
}
