﻿using ShopApp.Entities.FavouriteEntity;
using ShopApp.Entities.ManufactureEntity;
using ShopApp.Entities.OrderItemEntity;

namespace ShopApp.Entities.ProductEntity
{
    public class Product
    {
        public int VendorCode { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public uint Amount { get; set; }

        public int ManufacterId { get; set; }
        public Manufacter Manufacter { get; set; } = null!;

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public List<Favourite> Favourites { get; set; } = new List<Favourite>();
    }
}
