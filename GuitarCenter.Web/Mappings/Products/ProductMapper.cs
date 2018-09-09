using GuitarCenter.Model.Entities.Products;
using GuitarCenter.Web.Models.Products;
using System.Collections.Generic;

namespace GuitarCenter.Web.Mappings.Products
{
    public static class ProductMapper
    {
        public static List<ProductViewModel> ConvertToProductViewModelList(this List<Product> products)
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            foreach (Product product in products)
            {
                productViewModels.Add(product.ConvertToProductViewModel());
            }
            return productViewModels;
        }

        public static ProductViewModel ConvertToProductViewModel(this Product product)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.ProductId = product.ProductId;
            productViewModel.Name = product.Name;
            productViewModel.Description = product.Description;
            productViewModel.Price = product.Price.ToString();
            productViewModel.Color = product.Color;
            productViewModel.Size = product.Size;
            productViewModel.BrandId = product.Brand.BrandId;
            productViewModel.BrandName = product.Brand.Name;
            productViewModel.CategoryId = product.Category.CategoryId;
            productViewModel.CategoryName = product.Category.Name;

            if (product.ProductImage != null)
            {
                productViewModel.ProductImageViewModel = new ProductImageViewModel();
                productViewModel.ProductImageViewModel.ImageData = product.ProductImage.ImageData;
                productViewModel.ProductImageViewModel.ImageMimeType = product.ProductImage.ImageMimeType;
            }

            if (product.ProductImages != null)
            {
                productViewModel.ProductImageViewModels = new List<ProductImageViewModel>();
                foreach (var productImage in product.ProductImages)
                {
                    productViewModel.ProductImageViewModels.Add(new ProductImageViewModel() { ImageData = productImage.ImageData, ImageMimeType = productImage.ImageMimeType });
                }
            }

            return productViewModel;
        }
    }
}