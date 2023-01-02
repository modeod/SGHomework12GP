using ShopApp;
using ShopApp.Interface;
using ShopApp.Repositories;
using ShopApp.Repositories.Interfaces;

ShopDbContext shopDbContet = new ShopDbContext();
ICRUDOrders crudOrders = new OrderRepository(shopDbContet);
IReadStorage readStorage = new StorageRepository(shopDbContet);
IOrderManager orderManagerConsole = new OrderManagerConsole(crudOrders, readStorage);

orderManagerConsole.ShowMenu();
