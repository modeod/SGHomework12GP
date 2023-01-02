using GroupProject.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopApp.Entities.ProductEntity;

namespace ShopApp.DTO.MappingExtensions;

public static class ProductMappingExtension
{
    public static Product MapToProduct(this FoodProductDTO model)
    {
        return new Product
        {
            VendorCode = model.VendorCode,
            Price = model.Price,
            ProdType = model.ProdType,
            Name = model.Name,
            Amount = model.Amount,
            WeightUnit = model.WeightUnit,
            Weight = model.Weight,
            ExpiryDate = model.ExpiryDate,
            Currency = model.Currency
        };
    }

    public static FoodProductDTO MapToFoodProductDto(this Product model)
    {
        return new FoodProductDTO(
            model.VendorCode, model.Name, 
            model.ProdType, model.Price, 
            model.Amount, model.WeightUnit, 
            model.Weight, model.Currency, 
            model.ExpiryDate.Value
        );
    }

    public static Product MapToProduct(this MeatDTO model)
    {
        return new Product
        {
            VendorCode = model.VendorCode,
            Price = model.Price,
            ProdType = model.ProdType,
            Name = model.Name,
            Amount = model.Amount,
            WeightUnit = model.WeightUnit,
            Weight = model.Weight,
            MeatSort = model.MeatSort,
            MeatType = model.MeatType,
            ExpiryDate = model.ExpiryDate,
            Currency = model.Currency
        };
    }
    
    public static MeatDTO MapToMeat(this Product model)
    {
        return new MeatDTO(
            model.VendorCode, model.Name, 
            model.ProdType, model.Price, 
            model.Amount, model.WeightUnit,
            model.Weight, model.Currency, 
            model.ExpiryDate.Value,
            model.MeatSort.Value, model.MeatType.Value
        );
    }
    
    public static Product MapToProduct(this NonFoodProductDTO model)
    {
        return new Product
        {
            VendorCode = model.VendorCode,
            Price = model.Price,
            ProdType = model.ProdType,
            Name = model.Name,
            Amount = model.Amount,
            WeightUnit = model.WeightUnit,
            Weight = model.Weight,
            Description = model.Description,
            Currency = model.Currency
        };
    }
    
    public static NonFoodProductDTO MapToNonFoodProductDto(this Product model)
    {
        return new NonFoodProductDTO(
            model.VendorCode, model.Name, 
            model.ProdType, model.Price, 
            model.Amount, model.WeightUnit,
            model.Weight, model.Currency, 
            model.Description
        );
    }
    
    public static Product MapToProduct(this ProductDTO model)
    {
        return new Product
        {
            VendorCode = model.VendorCode,
            Price = model.Price,
            ProdType = model.ProdType,
            Name = model.Name,
            Amount = model.Amount,
            WeightUnit = model.WeightUnit,
            Weight = model.Weight,
            Currency = model.Currency
        };
    }
    
    public static ProductDTO MapToProductDto(this Product model)
    {
        return new ProductDTO(
            model.VendorCode, model.Name, 
            model.ProdType, model.Price, 
            model.Amount, model.WeightUnit,
            model.Weight, model.Currency
        );
    }
}