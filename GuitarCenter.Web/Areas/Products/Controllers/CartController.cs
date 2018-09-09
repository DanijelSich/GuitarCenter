using GuitarCenter.Model.Entities.Carts;
using GuitarCenter.Model.Entities.Orders;
using GuitarCenter.Model.Entities.Products;
using GuitarCenter.Model.Entities.Shipping;
using GuitarCenter.Web.Areas.Products.Models;
using System.Linq;
using System.Web.Mvc;

namespace GuitarCenter.Web.Areas.Products.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;

        public CartController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartPageViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.ReadAll()
                .FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.ReadAll()
                .FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult ShippingAddress()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult ShippingAddress(ShippingDetails model)
        {
            Order order = (Order)Session["Order"];
            order.ShippingDetails = model;
            return View("DeliveryOperator");
        }

        public ViewResult DeliveryOperator()
        {
            return View();
        }

        [HttpPost]
        public ViewResult DeliveryOperator(string operatorName)
        {
            Order order = (Order)Session["Order"];
            order.DeliveryOperator = DeliveryFactory.CreateDeliveryOperator(operatorName);
            return View("DiscountSelection");
        }

        public ViewResult DiscountSelection()
        {
            return View();
        }

        [HttpPost]
        public ViewResult DiscountSelection(string discountCode)
        {
            if (discountCode == "112233")
            {
                Order order = (Order)Session["Order"];
                order.Cart.SetCartDiscountStrategy("MoneyOff");
            }
            return View("OrderSummary", (Order)Session["Order"]);
        }

        private Cart GetCart()
        {
            Order order = (Order)Session["Order"];

            if (order == null)
            {
                order = new Order();
                order.Cart = new Cart();
                Session["Order"] = order;
            }
            return order.Cart;
        }
    }
}
