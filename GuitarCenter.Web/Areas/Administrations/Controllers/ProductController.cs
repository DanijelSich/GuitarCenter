using GuitarCenter.AppService.Abstractions.Brands;
using GuitarCenter.AppService.Abstractions.Categories;
using GuitarCenter.AppService.Abstractions.Products;
using GuitarCenter.AppService.Messages.Products;
using GuitarCenter.Model.Entities.Products;
using GuitarCenter.Web.Areas.Administrations.Models;
using GuitarCenter.Web.Mappings.Products;
using GuitarCenter.Web.Models.Products;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GuitarCenter.Web.Mappings.Brands;
using GuitarCenter.Web.Mappings.Categories;
using System.Web;

namespace GuitarCenter.Web.Areas.Administrations.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private IProductService productService;
        private IBrandService brandService;
        private ICategoryService categoryService;

        public ProductController(IProductService productService,
            IBrandService brandService,
            ICategoryService categoryService)
        {
            this.productService = productService;
            this.brandService = brandService;
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            ProductListPageViewModel model = new ProductListPageViewModel();
            FindAllProductsResponse response = productService.FindAllProducts();
            if (response.Success)
            {
                model.ProductViewModels = response.Products.ConvertToProductViewModelList();
                model.Success = true;
            }
            else
            {
                model.Success = false;
                model.ErrorMessage = response.Message;
            }

            return View(model);
        }

        public ActionResult Create()
        {
            ProductSinglePageViewModel model = new ProductSinglePageViewModel();
            model.ProductViewModel = new ProductViewModel();
            model.BrandViewModels = brandService.FindAllBrands().Brands.ConvertToBrandViewModelList();
            model.CategoryViewModels = categoryService.FindAllCategories().Categories.ConvertToCategoryViewModelList();
            model.Success = true;
            return View("Edit", model);
        }

        public ActionResult Edit(int productId)
        {
            ProductSinglePageViewModel model = new ProductSinglePageViewModel();
            FindAllProductsResponse response = productService.FindAllProducts();
            if (response.Success)
            {
                model.ProductViewModel = response.Products.
                    Where(x => x.ProductId == productId).
                    FirstOrDefault().
                    ConvertToProductViewModel();
                model.BrandViewModels = brandService.FindAllBrands().Brands.ConvertToBrandViewModelList();
                model.CategoryViewModels = categoryService.FindAllCategories().Categories.ConvertToCategoryViewModelList();
                model.Success = true;
            }
            else
            {
                model.Success = false;
                model.ErrorMessage = response.Message;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductSinglePageViewModel model, List<HttpPostedFileBase> fileUpload)
        {
            if (model.ProductViewModel.ProductId == 0)
            {
                CreateProductRequest request = new CreateProductRequest();
                CreateProductResponse response = new CreateProductResponse();
                request.Name = model.ProductViewModel.Name;
                request.Description = model.ProductViewModel.Description;
                request.Price = model.ProductViewModel.Price;
                request.Color = model.ProductViewModel.Color;
                request.Size = model.ProductViewModel.Size;
                request.BrandId = model.ProductViewModel.BrandId;
                request.CategoryId = model.ProductViewModel.CategoryId;
                request.ProductImages = new List<ProductImage>();

                foreach (HttpPostedFileBase image in fileUpload)
                {
                    if (image != null)
                    {
                        ProductImage productImeage = new ProductImage();
                        productImeage.ImageMimeType = image.ContentType;
                        productImeage.ImageData = new byte[image.ContentLength];
                        image.InputStream.Read(productImeage.ImageData, 0, image.ContentLength);
                        // First image add for displaying in product list page
                        if (request.ProductImage == null)
                        {
                            request.ProductImage = new ProductImage();
                            request.ProductImage = productImeage;
                        }
                        // Other images add to list
                        request.ProductImages.Add(productImeage);
                    }
                }

                response = productService.CreateProduct(request);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    model.Success = false;
                    model.ErrorMessage = response.Message;
                    return View(model);
                }
            }
            else
            {
                UpdateProductRequest request = new UpdateProductRequest();
                UpdateProductResponse response = new UpdateProductResponse();
                request.ProductId = model.ProductViewModel.ProductId;
                request.Name = model.ProductViewModel.Name;
                request.Description = model.ProductViewModel.Description;
                request.Price = model.ProductViewModel.Price;
                request.Color = model.ProductViewModel.Color;
                request.Size = model.ProductViewModel.Size;
                request.BrandId = model.ProductViewModel.BrandId;
                request.CategoryId = model.ProductViewModel.CategoryId;
                request.ProductImages = new List<ProductImage>();

                foreach (HttpPostedFileBase image in fileUpload)
                {
                    if (image != null)
                    {
                        ProductImage productImeage = new ProductImage();
                        productImeage.ImageMimeType = image.ContentType;
                        productImeage.ImageData = new byte[image.ContentLength];
                        image.InputStream.Read(productImeage.ImageData, 0, image.ContentLength);
                        // First image add for displaying in product list page
                        if (request.ProductImage == null)
                        {
                            request.ProductImage = new ProductImage();
                            request.ProductImage = productImeage;
                        }
                        // Other images add to list
                        request.ProductImages.Add(productImeage);
                    }
                }
                response = productService.UpdateProduct(request);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    model.Success = false;
                    model.ErrorMessage = response.Message;
                    return View(model);
                }
            }
        }

        public ActionResult Delete(int ProductId)
        {
            DeleteProductRequest request = new DeleteProductRequest();
            DeleteProductResponse response = new DeleteProductResponse();
            request.ProductId = ProductId;
            response = productService.DeleteProduct(request);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ProductListPageViewModel model = new ProductListPageViewModel();
                model.Success = false;
                model.ErrorMessage = response.Message;
                return View("Index", model);
            }
        }
    }
}
