using ShopApp;
using ShopApp.DTO.Enums;
using ShopApp.Entities.OrderEntity;
using ShopApp.Entities.OrderItemEntity;
using ShopApp.Entities.OrderStatusEntity;
using ShopApp.Interface;
using ShopApp.Repositories;
using ShopApp.Repositories.Interfaces;

ShopDbContext shopDbContet = new ShopDbContext();
ICRUDOrders crudOrders = new OrderRepository(shopDbContet);
IReadStorage readStorage = new StorageRepository(shopDbContet);
IUserRepository userRepository = new UserRepository(shopDbContet);
IOrderManager orderManagerConsole = new OrderManagerConsole(crudOrders, readStorage, userRepository);

await orderManagerConsole.ShowMenu();

//Console.WriteLine("ss");