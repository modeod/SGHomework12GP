using ShopApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.PaymentService
{
    public class CheckPay : IPayment
    {
        public bool Pay(uint _amount)
        {
            Console.WriteLine("Оплата готівкою");
            return true;
        }
    }
}
