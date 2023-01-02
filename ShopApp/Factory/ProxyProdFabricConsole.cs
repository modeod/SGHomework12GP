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
        public Type ProductTypeToCreate { get; private set; }

        public ProxyProdFabricConsole()
        {
            ProductTypeToCreate = null;
        }

        public Type ChooseProductType()
        {
            uint res;
            do
            {
                Console.WriteLine("Product Type (1 - Food, 2 - Meat, 3 - Vehicle): ");
                string input = Console.ReadLine();
                if (!uint.TryParse(input, out res)) { continue; }
            }
            while (res > 3 || res < 1);
            switch (res)
            {
                case 1:
                    ProductTypeToCreate = typeof(FoodProductDTO);
                    return typeof(FoodProductDTO);
                case 2:
                    ProductTypeToCreate = typeof(MeatDTO);
                    return typeof(MeatDTO);
                case 3:
                    ProductTypeToCreate = typeof(NonFoodProductDTO);
                    return typeof(NonFoodProductDTO);

                default:
                    Console.WriteLine("Incorrect number.");
                    return null;
            }
        }

        public ProductDTO CreateProduct()
        {
            var types = new Dictionary<Type, Func<ProductDTO>>();
            types[typeof(FoodProductDTO)] = () => CreateProductFoodProduct();
            types[typeof(MeatDTO)] = () => CreateProductMeat();
            types[typeof(NonFoodProductDTO)] = () => CreateProductNonProduct();

            if (types.Keys.Contains(ProductTypeToCreate))
            {
                return types[ProductTypeToCreate]?.Invoke();
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