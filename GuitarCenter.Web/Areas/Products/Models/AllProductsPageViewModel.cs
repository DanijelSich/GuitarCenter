using System;
using System.Collections.Generic;
using GuitarCenter.Web.Models.Products;
using System.Web;

namespace GuitarCenter.Web.Areas.Products.Models
{
    public class AllProductsPageViewModel
    {
        public List<ProductViewModel> ProductViewModels { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}