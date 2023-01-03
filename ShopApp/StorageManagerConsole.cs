using GroupProject.DTO;
using Microsoft.EntityFrameworkCore;
using ShopApp.DTO.MappingExtensions;
using ShopApp.Entities.ProductEntity;
using ShopApp.Interface;
using ShopApp.Repositories.Interfaces;
using System.Text;
using ShopApp.Facade;

namespace ShopApp
{
    public class StorageManagerConsole : IStorageManager
    {
        private ICRUDStorage storageCRUD;
        private IProxyProdFabric prodFabric;
        private readonly ConsoleHandler _consoleHandler;

        public StorageManagerConsole(ICRUDStorage storageCRUD, IProxyProdFabric prodFabric,
            ConsoleHandler consoleHandler)
        {
            this.storageCRUD = storageCRUD;
            this.prodFabric = prodFabric;
            _consoleHandler = consoleHandler;
        }
        public async Task ShowMenu()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            int menuCount;
            do
            {
                Console.WriteLine("1 - Добавити продукт");
                Console.WriteLine("2 - Видалити продукт");
                Console.WriteLine("3 - Оновити продукт");
                Console.WriteLine("4 - Показати продукти");
                Console.WriteLine("5 - Найти продукт по ID");
                Console.WriteLine("6 - Вихід");

                do
                {
                    Console.WriteLine("Введіть ваш вибір: ");
                    if (!int.TryParse(Console.ReadLine(), out menuCount))
                    {
                        Console.WriteLine("Потрібно ввести хоть якесь число!");
                        continue;
                    }
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
                            await CreateProduct();
                            break;
                        }
                    case 2:
                        {
                            await DeleteProduct();
                            break;
                        }
                    case 3:
                        {
                            await UpdateProduct();
                            break;
                        }
                    case 4:
                        {
                            await ReadProduct();
                            break;
                        }
                    case 5:
                        {
                            await FindProductsById();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Вихід.");
                            await _consoleHandler.ConfigureWorkWithSystem();
                            break;
                        }
                    default:
                        throw
                            new Exception("Помилка меню.");
                }
            } while (menuCount!=6);
            
        }
        
        public async Task CreateProduct()
        {
            Console.WriteLine("Створення продукта");
            Type typeProduct = prodFabric.ChooseProductType();
            ProductDTO newProductDTO = prodFabric.CreateProduct();
            Product generalProduct = DTOtoProduct(typeProduct, newProductDTO);
            
            try
            {
                await storageCRUD.CreateProduct(generalProduct);
                Console.WriteLine("Продукт створений");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Операція створення аварійно зупинена " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Аргумент має NULL значення " + ex.Message);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Помилка добавлення в репозиторій " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка створення продукту " + ex.Message);
            }
        }

        public async Task DeleteProduct()
        {
            Console.WriteLine("Щоб відмінити видалення введіть мінусове число");
            int indexProduct;
            do
            {
                Console.WriteLine("Введіть код продукта: ");
                if (!int.TryParse(Console.ReadLine(), out indexProduct))
                {
                    Console.WriteLine("Потрібно ввести хоть якесь число!");
                }
                if (indexProduct < 0) return;

                if (await storageCRUD.FindProductsById(indexProduct) == null)
                {
                    Console.WriteLine("Продукта з таким індексом не існує");
                    continue;
                }
                break;
            }
            while (true);

            try
            {
                await storageCRUD.DeleteProduct(indexProduct);
                Console.WriteLine("Продукт видалений");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Операція видалення аварійно зупинена " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Аргумент має NULL значення " + ex.Message);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Помилка видалення в репозиторію " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка видалення " + ex.Message);
            }
        }

        public async Task ReadProduct()
        {
            List<Product> listProduct = new List<Product>();

            try
            {
                listProduct = storageCRUD.ReadProducts().Result;
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Операція читання аварійно зупинена " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Аргумент має NULL значення " + ex.Message);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Помилка читання репозиторія " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка читання" + ex.Message);
            }

            if (listProduct.Count > 0)
            {
                foreach (Product product in listProduct)
                {
                    Console.WriteLine(ToStringProduct(product));
                }
            }
        }
        public async Task UpdateProduct()
        {
            Console.WriteLine("Щоб відмінити видалення введіть мінусове число");
            int indexProduct;
            do
            {
                Console.WriteLine("Введіть код продукта: ");
                if (!int.TryParse(Console.ReadLine(), out indexProduct))
                {
                    Console.WriteLine("Потрібно ввести хоть якесь число!");
                }
                if (indexProduct < 0) return;

                if (await storageCRUD.FindProductsById(indexProduct) == null)
                {
                    Console.WriteLine("Продукта з таким індексом не існує");
                    continue;
                }
                break;
            }
            while (true);

            Type typeProduct = prodFabric.ChooseProductType();
            ProductDTO newProductDTO = prodFabric.CreateProduct();
            Product generalProduct = DTOtoProduct(typeProduct, newProductDTO);

            generalProduct.VendorCode = indexProduct;

            try
            {
                await storageCRUD.UpdateProduct(generalProduct);
                Console.WriteLine("Продукт оновлений");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Операція оновлення аварійно зупинена " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Аргумент має NULL значення " + ex.Message);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Помилка оновлення продукту в репозиторію " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка оновлення " + ex.Message);
            }
        }

        public async Task FindProductsById()
        {
            Console.WriteLine("Щоб відмінити видалення введіть мінусове число");
            int indexProduct;
            do
            {
                Console.WriteLine("Введіть код продукта: ");
                if (int.TryParse(Console.ReadLine(), out indexProduct))
                {
                    if (indexProduct < 0) return;
                    break;
                }
                else
                    Console.WriteLine("Потрібно ввести хоть якесь число!");
            }
            while (true);
            Product? findProduct = storageCRUD.FindProductsById(indexProduct).Result;
            if (findProduct == null)
            {
                Console.WriteLine("По такому ID продукта нема");
            }
            else
            {
                Console.WriteLine(ToStringProduct(findProduct));
            }
        }

        private string ToStringProduct(Product product)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("ID: {0} | Назва продукту {1} | Тип продукту: {2} | Кількість: {3} | Одиниці ваги: {4} | Вага: {5} | Валюта: {6} | Ціна: {7} |", 
                product.VendorCode, product.Name, product.ProdType.ToString(), product.Amount.ToString(), product.WeightUnit.ToString(), product.Weight.ToString(), product.Currency.ToString(), product.Price.ToString());

            if (product.Description != null)
            {
                stringBuilder.AppendFormat(" Опис: {0}", product.Description.ToString());
            }
            if (product.MeatSort != null && product.MeatType != null)
            {
                stringBuilder.AppendFormat(" Сорт мяса: {0} | Тип мяса: {1} |", product.MeatSort.ToString(), product.MeatType.ToString());
            }
            if (product.ExpiryDate != null)
            {
                stringBuilder.AppendFormat(" Термін придатності: {0} |", product.ExpiryDate.ToString());
            }
            return stringBuilder.ToString();
        }
        private Product DTOtoProduct(Type typeProduct, ProductDTO productDTO)
        {
            if (typeProduct.Name == typeof(NonFoodProductDTO).Name)
            {
                return ((NonFoodProductDTO)productDTO).MapToProduct();
            }
            else if (typeProduct.Name == typeof(MeatDTO).Name)
            {
                return ((MeatDTO)productDTO).MapToProduct();
            }
            else if (typeProduct.Name == typeof(FoodProductDTO).Name)
            {
                return ((FoodProductDTO)productDTO).MapToProduct();
            }
            else
                throw new Exception("Не правильно створена фабрика");
        }
    }
}
