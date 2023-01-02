using GroupProject.DTO;
using GroupProject.factory;
using ShopApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Factory
{
    public class ProxyProdFabricConsole : IProxyProdFabric
    {
        Type productTypeToCreate;

        public ProxyProdFabricConsole()
        {
            productTypeToCreate = null;
        }

        public Type ChooseProductType()
        {
            try
            {
                uint res;
                do
                {
                    Console.WriteLine("Product Type (0 - Food, 1 - Meat, 2 - Vehicle): ");
                    string input = Console.ReadLine();
                    res = Convert.ToUInt32(input);
                }
                while (res > 2 || res < 0);

                switch (res)
                {
                    case 0:
                        productTypeToCreate = typeof(FoodProductDTO);
                        return typeof(FoodProductDTO);
                    case 1:
                        productTypeToCreate = typeof(MeatDTO);
                        return typeof(MeatDTO);
                    case 2:
                        productTypeToCreate = typeof(NonFoodProductDTO);
                        return typeof(NonFoodProductDTO);

                    default:
                        Console.WriteLine("Incorrect number. Try again.");
                        return ChooseProductType();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect formatting.");
                return ChooseProductType();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                return ChooseProductType();
            }
        }

        public ProductDTO CreateProduct()
        {
            var types = new Dictionary<Type, Func<ProductDTO>>();
            types[typeof(FoodProductDTO)] = () => CreateProductFoodProduct();
            types[typeof(MeatDTO)] = () => CreateProductMeat();
            types[typeof(NonFoodProductDTO)] = () => CreateProductNonProduct();

            Type productType = ChooseProductType();

            if (types.Keys.Contains(productType))
            {
                return types[productType]?.Invoke();
            }

            throw new ArgumentNullException();
        }

        private FoodProductDTO CreateProductFoodProduct()
        {
            ProductFoodFactory p = new();
            return p.CreateProduct();
        }

        private MeatDTO CreateProductMeat()
        {
            ProductMeatFactory p = new();
            return p.CreateProduct();
        }

        private NonFoodProductDTO CreateProductNonProduct()
        {
            NonFoodFactory p = new();
            return p.CreateProduct();
        }
    }
}