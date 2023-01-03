using ShopApp.Entities.OrderEntity;
using ShopApp.Factory;
using ShopApp.Interface;
using ShopApp.PaymentService;
using ShopApp.Repositories;
using ShopApp.Repositories.Interfaces;
using ShopApp.UI;

namespace ShopApp.Facade;

public class ConsoleHandler
{
    private readonly UserConsole _userConsole;
    private readonly OrderManagerConsole _orderManagerConsole;
    private readonly StorageManagerConsole _storageManagerConsole;
    
    private static readonly ShopDbContext _dbContext = new ShopDbContext();
    private IReadStorage storage = new StorageRepository(_dbContext);
    private IUserOrder orderRepository = new OrderRepository(_dbContext);
    private IProxyPay proxyPay = new ProxyPayConsole();
    private ICRUDOrders CRUDOrders = new OrderRepository(_dbContext);
    private IUserRepository userRepository = new UserRepository(_dbContext);
    private ICRUDStorage CRUDStorage = new StorageRepository(_dbContext);
    private IProxyProdFabric ProdFabric = new ProxyProdFabricConsole();

    public ConsoleHandler()
    {
        _userConsole = InjectUserConsole().Result;
        _orderManagerConsole = InjectOrderManagerConsole().Result;
        _storageManagerConsole = InjectStorageManagerConsole().Result;
    }

    public async Task ConfigureWorkWithSystem()
    {
        Console.Write("Enter your role: ");
        var role = Console.ReadLine();
        switch (role)
        {
            case "user":
                await _userConsole.ShowMenuAsync();
                break;
            case "ordermanager":
                await _orderManagerConsole.ShowMenu();
                break;
            case "storagemanager":
                await _storageManagerConsole.ShowMenu();
                break;
            default:
                throw new ArgumentException(nameof(role));
        }
    }

    private async Task<UserConsole> InjectUserConsole()
    {
        return new UserConsole(1, storage, orderRepository, proxyPay, null);
    }
    
    private async Task<OrderManagerConsole> InjectOrderManagerConsole()
    {
        return new OrderManagerConsole(CRUDOrders, storage, userRepository);
    }
    
    private async Task<StorageManagerConsole> InjectStorageManagerConsole()
    {
        return new StorageManagerConsole(CRUDStorage, ProdFabric);
    }
}