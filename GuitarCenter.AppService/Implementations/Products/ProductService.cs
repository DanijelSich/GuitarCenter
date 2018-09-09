using GuitarCenter.AppService.Abstractions.Products;
using GuitarCenter.AppService.Mappings.Products;
using GuitarCenter.AppService.Messages.Products;
using GuitarCenter.Model.Entities.Products;
using System;

namespace GuitarCenter.AppService.Implementations.Products
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public CreateProductResponse CreateProduct(CreateProductRequest request)
        {
            CreateProductResponse response = new CreateProductResponse();
            try
            {
                Product product = request.ConvertToProduct();
                productRepository.Create(product);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public DeleteProductResponse DeleteProduct(DeleteProductRequest request)
        {
            DeleteProductResponse response = new DeleteProductResponse();
            try
            {
                productRepository.Delete(request.ProductId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public UpdateProductResponse UpdateProduct(UpdateProductRequest request)
        {
            UpdateProductResponse response = new UpdateProductResponse();
            try
            {
                Product product = request.ConvertToProduct();
                productRepository.Update(product);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public FindAllProductsResponse FindAllProducts()
        {
            FindAllProductsResponse response = new FindAllProductsResponse();
            try
            {
                response.Products = productRepository.ReadAll();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
