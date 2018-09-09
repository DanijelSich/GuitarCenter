using System;
using System.Collections.Generic;
using GuitarCenter.Web.Models.Brands;
using System.Web;

namespace GuitarCenter.Web.Areas.Administrations.Models
{
    public class BrandSinglePageViewModel
    {
        public BrandViewModel BrandViewModel { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}