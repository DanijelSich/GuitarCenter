using GuitarCenter.Web.Models.Brands;
using System.Collections.Generic;

namespace GuitarCenter.Web.Areas.Administrations.Models
{
    public class BrandListPageViewModel
    {
        public List<BrandViewModel> BrandViewModels { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}