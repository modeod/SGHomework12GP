using AutoMapper;
using GroupProject.DTO;
using Microsoft.EntityFrameworkCore;
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
            throw new NotImplementedException();
        }
 
        public void CreateProduct()
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public void ReadProduct()
        {
            throw new NotImplementedException();
        }
        public void UpdateProduct()
        {
            throw new NotImplementedException();
        }
    }
}
