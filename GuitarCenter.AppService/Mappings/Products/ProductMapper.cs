using GuitarCenter.AppService.Messages.Products;
using GuitarCenter.Model.Entities.Brands;
using GuitarCenter.Model.Entities.Categories;
using GuitarCenter.Model.Entities.Products;
using System;

namespace GuitarCenter.AppService.Mappings.Products
{
    public static class ProductMapper
    {
        public static Product ConvertToProduct(this CreateProductRequest createRequest)
        {
            Product product = new Product();
            product.Name = createRequest.Name;
            product.Description = createRequest.Description;
            product.Price = Decimal.Parse(createRequest.Price);
            product.Color = createRequest.Color;
            product.Size = createRequest.Size;
            product.Brand = new Brand() { BrandId = createRequest.BrandId };
            product.Category = new Category() { CategoryId = createRequest.CategoryId };
            product.ProductImage = createRequest.ProductImage;
            product.ProductImages = createRequest.ProductImages;

            return product;
        }

        public static Product ConvertToProduct(this UpdateProductRequest updateRequest)
        {
            Product product = new Product();
            product.ProductId = updateRequest.ProductId;
            product.Name = updateRequest.Name;
            product.Description = updateRequest.Description;
            product.Price = Decimal.Parse(updateRequest.Price);
            product.Color = updateRequest.Color;
            product.Size = updateRequest.Size;
            product.Brand = new Brand() { BrandId = updateRequest.BrandId };
            product.Category = new Category() { CategoryId = updateRequest.CategoryId };
            product.ProductImage = updateRequest.ProductImage;
            product.ProductImages = updateRequest.ProductImages;

            return product;
        }
    }
}