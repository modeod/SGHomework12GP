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
        IPayment? payment;
        public ProxyPayConsole()
        {
            payment = null;
        }

        public IPayment ChoosePaymentSystem()
        {
            Console.WriteLine("1 - Платити готівкою");
            Console.WriteLine("2 - Платити карткою");

            int menuCount;
            do
            {
                Console.WriteLine("Введіть ваш вибір: ");
                if (!int.TryParse(Console.ReadLine(), out menuCount))
                {
                    Console.WriteLine("Потрібно ввести хоть якесь число!");
                    continue;
                }
                else 
                if (menuCount < 1  || menuCount > 2)
                {
                    Console.WriteLine("Введіть дані числа меню!");
                }
            } 
            while (menuCount < 1 || menuCount > 2);

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

        public bool Pay(decimal _amount)
        {
            payment = ChoosePaymentSystem();
            return payment.Pay(_amount);
        }
    }
}
