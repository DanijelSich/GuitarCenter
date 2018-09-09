using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace GuitarCenter.Web.Models.Brands
{
    public class BrandViewModel
    {
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Ime brenda mora biti uneto")]
        [StringLength(50, ErrorMessage = "Ime mora biti manje od 50 karaktera")]
        public string Name { get; set; }
    }
}