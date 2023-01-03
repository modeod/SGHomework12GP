using ShopApp.Entities.OrderEntity;
using ShopApp.Entities.OrderItemEntity;
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
        private int userId;
        public Order CurrentOrder { get; set; }

        public UserConsole()
        {

        }
        public UserConsole(int userId,IReadStorage storage, IUserOrder orderService, IProxyPay payment, Order currentOrder)
        {
            this.storage = storage;
            this.orderService = orderService;
            this.payment = payment;
            CurrentOrder = currentOrder;
            this.userId = userId;
        }
        public void ShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(">>> Вiтаємо у нашому магазинi та бажаємо приємних покупок! <<<");
            Console.ResetColor();
            while (true)
            {
                Console.WriteLine("Оберiть номер пункта меню:".Replace('і', 'i'));
                Console.WriteLine("1. Вивести весь список продуктів.".Replace('і', 'i'));
                Console.WriteLine("2. Знайти продукт за номером.");
                Console.WriteLine("3. Показати мої замовлення.");
                Console.WriteLine("4. Оновити поточне замовлення.");
                Console.WriteLine("5. Підтвердити поточне замовлення.".Replace('і', 'i'));
                Console.WriteLine("6. Сплатити поточне замовлення.");
                Console.WriteLine("7. Вихiд.");
                int choose;
                try
                {
                   choose = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception)
                {
                    choose = 0;
                }
                switch (choose)
                { 
                    case 1:
                        Console.Clear();
                        ShowListOfProducts();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Введiть номер продукта для пошуку:");
                        if (Int32.TryParse(Console.ReadLine(), out int productNumber))
                        {
                            FindProductsById(productNumber);
                            break;
                        }
                        Console.WriteLine("Некорректний номер продукту.");
                        break;
                    case 3:
                        Console.Clear();
                        GetMyOrders();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Введiть номер продукту, який бажаєте додати до замовлення:");
                        if(Int32.TryParse(Console.ReadLine(), out productNumber))
                        {
                            Console.WriteLine("Введiть кiлькiсть продуктiв, який бажаєте додати до замовлення:");
                            if(Int32.TryParse(Console.ReadLine(),out int amount))
                            {
                                UpdateCurrentOrder(FindProductsById(productNumber), amount);
                                break;
                            }
                        }
                        Console.WriteLine("Некорректний номер продукту або його кiлькiсть");
                        break;
                    case 5:
                        Console.Clear();
                        ApplyOrder();
                        break;
                    case 6:
                        Console.Clear();
                        ApplyPayment();
                        break;
                    case 7:
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(">>> Дякуємо, що завiтали до нас! <<<");
                        Console.ResetColor();
                        return;
                    default:
                        Console.WriteLine("Введіть число зі списку.");
                        break;
                }

            }

        }
        async public void GetMyOrders()
        {
            try
            {
                var myOrders =(await orderService.GetAll()).Where(x => x.UserId == userId);
                foreach (var item in myOrders)
                {
                    decimal totalPrice = 0;
                    Console.WriteLine($"Дата замовлення:{item.OrderedAt}");
                    foreach (var orderItem in item.OrderItems)
                    {
                        Console.WriteLine($"{orderItem.Product.Name}............{orderItem.Amount} шт. {orderItem.PriceWithSale}");
                        totalPrice += orderItem.PriceWithSale;
                    }
                    Console.WriteLine($"Вартість: {totalPrice}");
                    Console.WriteLine(new String('=', 50));
                }
            }
            catch(Exception)
            {
                Console.WriteLine("У Вас не має створених замовлень.");
            }
        }

        async public void ShowListOfProducts()
        {
            try
            {
             var products = await storage.ReadProducts();
                foreach (var product in products)
                {
                    ShowProduct(product);
                    Console.WriteLine(new string('-', 30));
                }
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("Продуктiв не знайдено.");
            }
        }

        public Product? FindProductsById(int id)
        {
            try
            {
                var product = storage.FindProductsById(id).Result;
                if (product is null)
                {
                    Console.WriteLine("Продуктiв з таким номером не знайдено.");
                }
                else
                {
                    ShowProduct(product);
                    Console.WriteLine(new string('-', 30));
                }
                return product;
            }
            catch(Exception) 
            {
                Console.WriteLine("Продукт з таким номером не знайдено.");
            }
            return null;
        }
       
        private void ShowProduct(Product product)
        {
            Console.WriteLine($"{product.Name} {product.Price}\nОпис: {product.Description}");
        }

        public void UpdateCurrentOrder(Product product, int amount)
        {
            if(product is null || amount<=0)
            {
                Console.WriteLine("Iнформацiя про товар або кiлькi сть введено неправильно.");
                return;
            }
            if(CurrentOrder is null)
            {
                CurrentOrder = new Order();
            }
            var newOrderItem = new OrderItem()
            {
                Id = CurrentOrder.OrderItems.Count == 0 ? 0 : CurrentOrder.OrderItems.Count,
                Amount = amount,
                Product = product,
                ProductVendorCode = product.VendorCode
            };
            CurrentOrder.OrderItems.Add(newOrderItem);

        }

        public void ApplyOrder()
        {
            if(CurrentOrder is null)
            {
                CurrentOrder= new Order();
            }
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
