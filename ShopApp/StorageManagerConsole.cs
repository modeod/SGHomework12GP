﻿using GroupProject.DTO;
using GroupProject.DTO.Enums;
using Microsoft.EntityFrameworkCore;
using ShopApp.DTO.MappingExtensions;
using ShopApp.Entities.ProductEntity;
using ShopApp.Interface;
using ShopApp.PaymentService;
using ShopApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp
{
    public class StorageManagerConsole : IStorageManager
    {
        private ICRUDStorage storageCRUD;
        private IProxyProdFabric prodFabric;

        public StorageManagerConsole(ICRUDStorage storageCRUD, IProxyProdFabric prodFabric)
        {
            this.storageCRUD = storageCRUD;
            this.prodFabric = prodFabric;
        }
        public void ShowMenu()
        {
            Console.WriteLine("1 - Добавити продукт");
            Console.WriteLine("2 - Видалити продукт");
            Console.WriteLine("3 - Оновити продукт");
            Console.WriteLine("4 - Показати продукти");
            Console.WriteLine("5 - Найти продукт по ID");
            Console.WriteLine("6 - Вихід");

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
                        CreateProduct();
                        break;
                    }
                case 2:
                    {
                        DeleteProduct();
                        break;
                    }
                case 3:
                    {
                        ReadProduct();
                        break;
                    }
                case 4:
                    {
                        UpdateProduct();
                        break;
                    }
                case 5:
                    {
                        FindProductsById();
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Вихід.");
                        break;
                    }
                default:
                    throw
                        new Exception("Помилка меню.");
            }
        }
 
        public void CreateProduct()
        {
            Console.WriteLine("Створення продукта");
            Type typeProduct = prodFabric.ChooseProductType();
            ProductDTO newProductDTO = prodFabric.CreateProduct();
            Product generalProduct;
            if (newProductDTO is NonFoodProductDTO nonFoodProductDTO)
            {
                generalProduct = nonFoodProductDTO.MapToProduct();
            }
            else 
                if (newProductDTO is MeatDTO meatDTO)
            {
                generalProduct = meatDTO.MapToProduct();
            }
            else 
                if (newProductDTO is FoodProductDTO foodProductDTO)
            {
                generalProduct = foodProductDTO.MapToProduct();
            }
            else 
                throw
                    new ArgumentException("Не правильно створена фабрика");
            try
            {
                if (storageCRUD.CreateProduct(generalProduct).Result != null)
                {
                    Console.WriteLine("Продукт створений");
                }
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

        public void DeleteProduct()
        {
            Console.WriteLine("Щоб відмінити видалення введіть мінусове число");
            int indexProduct;
            do
            {
                Console.WriteLine("Введіть код продукта: ");
                if (int.TryParse(Console.ReadLine(), out indexProduct))
                {
                    break;
                }
                else
                    Console.WriteLine("Потрібно ввести хоть якесь число!");
            }
            while (indexProduct != -1);

            try
            {
                if (storageCRUD.DeleteProduct(indexProduct).Result != null)
                {
                    Console.WriteLine("Продукт видалений");
                }
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

        public void ReadProduct()
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
        public void UpdateProduct()
        {
            Product generalProduct;
            Console.WriteLine("Щоб відмінити оновлення введіть мінусове число");
            int indexProduct;
            do
            {
                Console.WriteLine("Введіть код продукта: ");
                if (int.TryParse(Console.ReadLine(), out indexProduct))
                {
                    break;
                }
                else
                    Console.WriteLine("Потрібно ввести хоть якесь число!");
            }
            while (indexProduct != -1);

            prodFabric.ChooseProductType();
            ProductDTO newProductDTO = prodFabric.CreateProduct();

            if (newProductDTO is NonFoodProductDTO nonFoodProductDTO)
            {
                generalProduct = nonFoodProductDTO.MapToProduct();
            }
            else
                if (newProductDTO is MeatDTO meatDTO)
            {
                generalProduct = meatDTO.MapToProduct();
            }
            else
                if (newProductDTO is FoodProductDTO foodProductDTO)
            {
                generalProduct = foodProductDTO.MapToProduct();
            }
            else
                throw
                    new ArgumentException("Не правильно створена фабрика");

            generalProduct.VendorCode = indexProduct;

            try
            {
                if (storageCRUD.UpdateProduct(generalProduct).Result != null)
                {
                    Console.WriteLine("Продукт оновлений");
                }
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

        public void FindProductsById()
        {
            Console.WriteLine("Щоб відмінити видалення введіть мінусове число");
            int indexProduct;
            do
            {
                Console.WriteLine("Введіть код продукта: ");
                if (int.TryParse(Console.ReadLine(), out indexProduct))
                {
                    break;
                }
                else
                    Console.WriteLine("Потрібно ввести хоть якесь число!");
            }
            while (indexProduct != -1);
            Product findProduct = storageCRUD.FindProductsById(indexProduct).Result;
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
            string result = "";
            result += product.VendorCode+" | ";
            result += product.ProdType + " | ";
            result += product.Name + " | ";
            result += product.Description!=null? product.Description + " | " : "";
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
