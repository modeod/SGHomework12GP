using ShopApp.DTO;
using ShopApp.Interface;
using ShopApp.Repositories.Interfaces;

namespace ShopApp
{
    public class OrderManagerConsole : IOrderManager
    {
        protected readonly ICRUDOrders crudOrder;
        protected readonly IReadStorage readStorage;

        public OrderManagerConsole(ICRUDOrders crudOrder, IReadStorage readStorage)
        {
            this.crudOrder = crudOrder;
            this.readStorage = readStorage;
        }

        public async Task CreateOrder()
        {
            var orderToCreateDTO = new OrderDTO();
            
            //var createdOrder = await crudOrder.CreateOrder();

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

        public void ShowMenu()
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
                Console.WriteLine("Введіть ваш вибір: ");
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
                        CreateOrder();
                        break;
                    }
                case 2:
                    {
                        ReadOrders();
                        break;
                    }
                case 3:
                    {
                        UpdateOrder();
                        break;
                    }
                case 4:
                    {
                        DeleteOrder();
                        break;
                    }
                case 5:
                    {
                        FindOrderById();
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
    }
}
