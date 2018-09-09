using GuitarCenter.AppService.Abstractions.Brands;
using GuitarCenter.AppService.Mappings.Brands;
using GuitarCenter.AppService.Messages.Brands;
using GuitarCenter.Model.Entities.Brands;
using System;

namespace GuitarCenter.AppService.Implementations.Brands
{
    public class BrandService : IBrandService
    {
        private IBrandRepository brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public CreateBrandResponse CreateBrand(CreateBrandRequest request)
        {
            CreateBrandResponse response = new CreateBrandResponse();
            try
            {
                Brand brand = request.ConvertToBrand();
                brandRepository.Create(brand);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public DeleteBrandResponse DeleteBrand(DeleteBrandRequest request)
        {
            DeleteBrandResponse response = new DeleteBrandResponse();
            try
            {
                brandRepository.Delete(request.BrandId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public FindAllBrandsResponse FindAllBrands()
        {
            FindAllBrandsResponse response = new FindAllBrandsResponse();
            try
            {
                response.Brands = brandRepository.ReadAll();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public UpdateBrandResponse UpdateBrand(UpdateBrandRequest request)
        {
            UpdateBrandResponse response = new UpdateBrandResponse();
            try
            {
                Brand brand = request.ConvertToBrand();
                brandRepository.Update(brand);
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