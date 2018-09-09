using GuitarCenter.AppService.Messages.Brands;
using GuitarCenter.Model.Entities.Brands;

namespace GuitarCenter.AppService.Mappings.Brands
{
    public static class BrandMapper
    {
        public static Brand ConvertToBrand(this CreateBrandRequest createRequest)
        {
            Brand brand = new Brand();
            brand.Name = createRequest.Name;

            return brand;
        }

        public static Brand ConvertToBrand(this UpdateBrandRequest updateRequest)
        {
            Brand brand = new Brand();
            brand.BrandId = updateRequest.BrandId;
            brand.Name = updateRequest.Name;

            return brand;
        }
    }
}