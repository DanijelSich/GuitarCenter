using System;
using System.Collections.Generic;
using GuitarCenter.Web.Models.Categories;
using System.Web;

namespace GuitarCenter.Web.Areas.Administrations.Models
{
    public class CategoryListPageViewModel
    {
        public List<CategoryViewModel> CategoryViewModels { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}