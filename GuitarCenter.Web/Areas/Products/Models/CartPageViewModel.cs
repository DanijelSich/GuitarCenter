using GuitarCenter.Model.Entities.Carts;

namespace GuitarCenter.Web.Areas.Products.Models
{
    public class CartPageViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
