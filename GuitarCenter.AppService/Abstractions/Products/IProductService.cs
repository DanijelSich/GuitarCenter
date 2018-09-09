using GuitarCenter.AppService.Messages.Products;

namespace GuitarCenter.AppService.Abstractions.Products
{
    public interface IProductService
    {
        FindAllProductsResponse FindAllProducts();
        CreateProductResponse CreateProduct(CreateProductRequest request);
        UpdateProductResponse UpdateProduct(UpdateProductRequest request);
        DeleteProductResponse DeleteProduct(DeleteProductRequest request);
    }
}