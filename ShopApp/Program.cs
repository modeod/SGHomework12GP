using ShopApp;
using ShopApp.Repositories;

var repo = new StorageRepository(new ShopDbContext());
var product = new ShopApp.Entities.ProductEntity.Product()
{
    VendorCode = 5,
    ManufacterId = 2
};
try
{
    await repo.CreateProduct(null);
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}
