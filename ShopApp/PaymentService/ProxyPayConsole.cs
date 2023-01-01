using ShopApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.PaymentService
{
    public class ProxyPayConsole : IProxyPay
    {
        IPayment payment;
        public ProxyPayConsole()
        {
            payment = null;
        }
        public ProxyPayConsole(IPayment payment)
        {
            this.payment = payment;
        }

        public IPayment ChoosePayment()
        {
            Console.WriteLine("1 - Платити готівкою");
            Console.WriteLine("2 - Платити карткою");
            int menuCount;
            do
            {
                if (int.TryParse(Console.ReadLine(), out menuCount))
                {
                    Console.WriteLine("Введість число меню!");
                }
                else 
                if (menuCount < 0 && menuCount > 2)
                {
                    Console.WriteLine("Введіть дані числа меню!");
                }

            } 
            while (menuCount < 0);
            switch (menuCount)
            {
                case 1:
                    return 
                        new CheckPay();
                case 2:
                    return 
                        new CreditCardPay();
                default:
                    throw 
                        new Exception("Помилка вибору оплати.");
            }
            throw 
                new Exception("Помилка вибору оплати.");
        }

        public bool Pay(uint _amount)
        {
            return payment.Pay(_amount);
        }
    }
}
