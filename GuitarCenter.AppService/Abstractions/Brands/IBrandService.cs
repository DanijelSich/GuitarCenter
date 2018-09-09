using System;
using System.Collections.Generic;
using GuitarCenter.AppService.Messages.Brands;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.AppService.Abstractions.Brands
{
    public interface IBrandService
    {
        CreateBrandResponse CreateBrand(CreateBrandRequest request);
        FindAllBrandsResponse FindAllBrands();
        UpdateBrandResponse UpdateBrand(UpdateBrandRequest request);
        DeleteBrandResponse DeleteBrand(DeleteBrandRequest request);
    }
}