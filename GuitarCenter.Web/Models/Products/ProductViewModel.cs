using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace GuitarCenter.Web.Models.Products
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Ime proizvoda mora biti uneto")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Opis proizvoda mora biti unet")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Cena proizvoda mora biti uneta")]
        public string Price { get; set; }
        [Required(ErrorMessage = "Boja proizvoda mora biti uneta")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Veličina proizvoda mora biti uneta")]
        public string Size { get; set; }
        [Required(ErrorMessage = "Brend mora biti unet")]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        [Required(ErrorMessage = "Kategorija mora biti uneta")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ProductImageViewModel ProductImageViewModel { get; set; }
        public List<ProductImageViewModel> ProductImageViewModels { get; set; }
    }
}