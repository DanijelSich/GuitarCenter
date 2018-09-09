using GuitarCenter.AppService.Abstractions.Products;
using GuitarCenter.AppService.Messages.Products;
using GuitarCenter.Web.Areas.Products.Models;
using GuitarCenter.Web.Mappings.Products;
using GuitarCenter.Web.Models.Products;
using System.Web.Mvc;

namespace GuitarCenter.Web.Areas.Products.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: Products/Product
        public ActionResult Index()
        {
            FindAllProductsResponse response = new FindAllProductsResponse();
            response = productService.FindAllProducts();

            AllProductsPageViewModel model = new AllProductsPageViewModel();
            model.ProductViewModels = response.Products.ConvertToProductViewModelList();
            model.Success = response.Success;
            model.ErrorMessage = response.Message;

            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            ProductViewModel productViewModel = productService.FindAllProducts().Products.
                Find(x => x.ProductId == productId).ConvertToProductViewModel();
            if (productViewModel != null)
            {
                return File(productViewModel.ProductImageViewModel.ImageData, productViewModel.ProductImageViewModel.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}