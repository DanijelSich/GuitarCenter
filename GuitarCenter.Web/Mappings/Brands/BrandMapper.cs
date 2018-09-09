using GuitarCenter.Model.Entities.Brands;
using GuitarCenter.Web.Models.Brands;
using System.Collections.Generic;

namespace GuitarCenter.Web.Mappings.Brands
{
    public static class BrandMapper
    {
        public static List<BrandViewModel> ConvertToBrandViewModelList(this List<Brand> brands)
        {
            List<BrandViewModel> brandViewModels = new List<BrandViewModel>();
            foreach (Brand brand in brands)
            {
                brandViewModels.Add(brand.ConvertToBrandViewModel());
            }
            return brandViewModels;
        }

        public static BrandViewModel ConvertToBrandViewModel(this Brand brand)
        {
            BrandViewModel brandViewModel = new BrandViewModel();
            brandViewModel.BrandId = brand.BrandId;
            brandViewModel.Name = brand.Name;

            return brandViewModel;
        }
    }
}