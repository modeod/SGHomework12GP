using ShopApp.DTO;
using ShopApp.DTO.Enums;
using ShopApp.Entities.OrderEntity;
using ShopApp.Entities.OrderItemEntity;
using ShopApp.Entities.OrderStatusEntity;
using ShopApp.Entities.ProductEntity;
using ShopApp.Interface;
using ShopApp.Repositories;
using ShopApp.Repositories.Interfaces;

namespace ShopApp
{
    public class OrderManagerConsole : IOrderManager
    {
        protected readonly ICRUDOrders crudOrder;
        protected readonly IReadStorage readStorage;
        protected readonly IUserRepository userRepository;

        public OrderManagerConsole(ICRUDOrders crudOrder, IReadStorage readStorage, IUserRepository userRepository)
        {
            this.crudOrder = crudOrder;
            this.readStorage = readStorage;
            this.userRepository = userRepository;
        }

        public async Task CreateOrder()
        {
            var orderToCreate = new Order();
            var user = await userRepository.GetById(4);
            if (user == null)
            {
                Console.WriteLine("Користувача не знайдено");
                return;
            }

            Console.WriteLine("Створення замовлення...");

            var allProducts = await readStorage.ReadProducts();
            Console.WriteLine("Список всiх продуктiв: ");
            foreach (var item in allProducts)
            {
                Console.WriteLine(ToStringProduct(item));
            }
            
            Console.WriteLine("Виберiть необхiднi продукти (Vendor code)");
            var userProductsVendorCode = Console.ReadLine();
            
            if (userProductsVendorCode == null || userProductsVendorCode.Length == 0 || userProductsVendorCode == "")
            {
                Console.WriteLine("Жоден продукт не вибрано");
                return;
            }
            
            var productsVendorCode = userProductsVendorCode?.Split(',', ' ');
            int[] vendorCodeArr = new int[] { };
            if (productsVendorCode == null || productsVendorCode.Length == 0)
            {
                Console.WriteLine("Жоден продукт не вибрано");
            }
            else
            {
                vendorCodeArr = Array.ConvertAll(productsVendorCode, s => int.TryParse(s, out var x) ? x : -1);
            }
            
            foreach (var item in vendorCodeArr)
            {
                var productById = await readStorage.FindProductsById(item);
                if (productById != null)
                {
                    var orderItem = new OrderItem()
                    {
                        ProductVendorCode = productById.VendorCode,
                        PriceWithSale = productById.Price
                    };

                    Console.Write($"Введiть к-ть {productById.Name}: ") ;
                    var isSuccess = int.TryParse(Console.ReadLine(), out var productCount);
                    orderItem.Amount = isSuccess ? productCount : 1;

                    orderToCreate.OrderItems.Add(orderItem);
                    Console.WriteLine($"Продукт: {item} успiшно додано");
                }
                else
                {
                    Console.WriteLine($"Продукт: {item} не знайдено");
                }
            }

            Console.Write("Введiть опис замовлення: ");
            orderToCreate.Description = Console.ReadLine();
            orderToCreate.UserId = user.Id;
            orderToCreate.AddressId = user.AddressId;
            orderToCreate.StatusId = (int)OrderStatuses.Pending;
            orderToCreate.OrderedAt = DateTime.Now;

            var createdOrder = await crudOrder.CreateOrder(orderToCreate);
            Console.WriteLine("Замовлення успішно додано");
        }
        public async Task ReadOrders()
        {
            //var orders = await crudOrder.GetAll();

            //foreach (var item in orders)
            //{
            //    Console.WriteLine(item.);
            //}
        }
        public async Task UpdateOrder()
        {
            
        }

        public async Task DeleteOrder()
        {
            
        }

        public async Task FindOrderById()
        {

        }

        public async Task ShowMenu()
        {
            Console.WriteLine("1 - Додати замовлення");
            Console.WriteLine("2 - Показати замовлення");
            Console.WriteLine("3 - Оновити замовлення");
            Console.WriteLine("4 - Видалити замовлення");
            Console.WriteLine("5 - Знайти замовлення по ID");
            Console.WriteLine("6 - Вихiд");

            int menuCount;
            do
            {
                Console.WriteLine("Введiть ваш вибiр: ");
                if (!int.TryParse(Console.ReadLine(), out menuCount))
                {
                    Console.WriteLine("Потрібно ввести хоть якесь число!");
                    continue;
                }
                else
                if (menuCount < 1 || menuCount > 6)
                {
                    Console.WriteLine("Введіть дані числа меню!");
                }
            }
            while (menuCount < 1 || menuCount > 6);

            switch (menuCount)
            {
                case 1:
                    {
                        await CreateOrder();
                        break;
                    }
                case 2:
                    {
                        await ReadOrders();
                        break;
                    }
                case 3:
                    {
                        await UpdateOrder();
                        break;
                    }
                case 4:
                    {
                        await DeleteOrder();
                        break;
                    }
                case 5:
                    {
                        await FindOrderById();
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Вихiд.");
                        break;
                    }
                default:
                    throw
                        new Exception("Помилка меню.");
            }
        }

        private string ToStringProduct(Product product)
        {
            string result = "";
            result += "VendorCode:" + product.VendorCode + " | ";
            result += product.ProdType + " | ";
            result += product.Name + " | ";
            result += product.Description != null ? product.Description + " | " : "";
            result += product.Amount + " | ";
            result += product.WeightUnit + " | ";
            result += product.Weight.ToString() + " | ";
            result += product.Weight + " | ";
            result += product.MeatSort != null ? product.MeatSort.ToString() + " | " : "";
            result += product.MeatType != null ? product.MeatType.ToString() + " | " : "";
            result += product.ExpiryDate != null ? product.ExpiryDate.ToString() + " | " : "";
            result += product.Currency + " | ";
            return result;
        }
    }
}
