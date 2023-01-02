using ShopApp.Factory;

ProxyProdFabricConsole p = new();

var res = p.CreateProduct();

Console.WriteLine(res.GetType());