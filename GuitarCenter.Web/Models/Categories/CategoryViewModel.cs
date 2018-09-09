using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace GuitarCenter.Web.Models.Categories
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Ime kategorije mora biti uneto")]
        [StringLength(50, ErrorMessage = "Ime mora biti manje od 50 karaktera")]
        public string Name { get; set; }
    }
}