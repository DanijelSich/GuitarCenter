using GuitarCenter.Web.Models.Brands;
using GuitarCenter.Web.Models.Categories;
using GuitarCenter.Web.Models.Products;
using System.Collections.Generic;

namespace GuitarCenter.Web.Areas.Administrations.Models
{
    public class ProductSinglePageViewModel
    {
        public ProductViewModel ProductViewModel { get; set; }
        public List<BrandViewModel> BrandViewModels { get; set; }
        public List<CategoryViewModel> CategoryViewModels { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}