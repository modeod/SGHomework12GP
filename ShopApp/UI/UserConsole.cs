using ShopApp.Entities.OrderEntity;
using ShopApp.Entities.ProductEntity;
using ShopApp.Interface;
using ShopApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.UI
{
    internal class UserConsole
    {
        private IReadStorage storage;
        private IUserOrder orderService;
        private IProxyPay payment;

        public Order CurrentOrder { get; set; }

        public UserConsole(IReadStorage storage, IUserOrder orderService, IProxyPay payment, Order currentOrder)
        {
            this.storage = storage;
            this.orderService = orderService;
            this.payment = payment;
            CurrentOrder = currentOrder;
        }
        public void ShowMenu()
        {
            Console.WriteLine("Оберiть номер пункта меню:".Replace('і', 'i'));
            Console.WriteLine("1. Вивести весь список продуктів.".Replace('і', 'i'));
            Console.WriteLine("2. Знайти продукт за номером.");
            Console.WriteLine("3. Показати мої замовлення.");
            Console.WriteLine("4. Знайти продукт за номером.");
            Console.WriteLine("5. Оновити поточне замовлення.");
            Console.WriteLine("7. Підтвердити поточне замовлення.".Replace('і', 'i'));
            Console.WriteLine("8. Сплатити поточне замовлення.");
        }
        public void GetMyOrders()
        {
            //TODO change user ID
            var myOrders = orderService.GetAll().Result.Where(x => x.UserId == 0);
            foreach (var item in myOrders)
            {
                decimal totalPrice = 0;
                Console.WriteLine($"Дата замовлення:{item.OrderedAt}");
                foreach (var orderItem in item.OrderItems)
                {
                    Console.WriteLine($"{orderItem.Product.Name}............{orderItem.Amount} шт. {orderItem.Amount * orderItem.PriceWithSale}");
                    totalPrice += orderItem.Amount * orderItem.PriceWithSale;
                }
                Console.WriteLine($"Вартість: {totalPrice}");
                Console.WriteLine(new String('=', 50));
            }
        }

        public void ShowListOfProducts()
        {
            var products = storage.ReadProducts().Result;
            foreach (var product in products)
            {
                ShowProduct(product);
                Console.WriteLine(new string('-', 30));
            }
        }

        public void FindProductsById(int id)
        {

            var product = storage.FindProductsById(id).Result;
            if (product is null)
            {
                Console.WriteLine("Продуктiв з такою назвою не знайдено.");
            }
            else
            {
                ShowProduct(product);
                Console.WriteLine(new string('-', 30));
            }
        }



        private void ShowProduct(Product product)
        {
            Console.WriteLine($"{product.Name}:\nОпис: {product.Description}");
            Console.WriteLine($"Виробник: {product.Manufacter.Title}");
        }

        public void UpdateCurrentOrder()
        {

        }

        public void ApplyOrder()
        {
            CurrentOrder.OrderedAt = DateTime.Now;
            if (orderService.CreateOrder(CurrentOrder).Result is not null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Замовлення вдало створено.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Виникли помилки при створеннi замовлення.");
                Console.ResetColor();
            }
        }

        public void ApplyPayment()
        {
            payment.ChoosePaymentSystem();
        }
    }
}
