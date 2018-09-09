using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuitarCenter.Web.Models.Products
{
    public class ProductImageViewModel
    {
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}