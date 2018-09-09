using System;
using System.Collections.Generic;
using GuitarCenter.Web.Models.Categories;
using System.Web;

namespace GuitarCenter.Web.Areas.Administrations.Models
{
    public class CategorySinglePageViewModel
    {
        public CategoryViewModel CategoryViewModel { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}