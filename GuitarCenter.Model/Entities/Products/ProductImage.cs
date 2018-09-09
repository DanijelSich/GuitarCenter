using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.Model.Entities.Products
{
    public class ProductImage
    {
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}