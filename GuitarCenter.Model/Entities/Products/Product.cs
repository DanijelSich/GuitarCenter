using GuitarCenter.Model.Entities.Brands;
using GuitarCenter.Model.Entities.Categories;
using System.Collections.Generic;

namespace GuitarCenter.Model.Entities.Products
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

        public Brand Brand { get; set; }
        public Category Category { get; set; }

        public ProductImage ProductImage { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}