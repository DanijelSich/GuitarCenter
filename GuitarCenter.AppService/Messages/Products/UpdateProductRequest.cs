using System;
using System.Collections.Generic;
using GuitarCenter.Model.Entities.Products;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.AppService.Messages.Products
{
    public class UpdateProductRequest
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public ProductImage ProductImage { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}