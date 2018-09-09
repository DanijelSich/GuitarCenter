using GuitarCenter.AppService.Abstractions.Brands;
using GuitarCenter.AppService.Messages.Brands;
using GuitarCenter.Web.Areas.Administrations.Models;
using System.Linq;
using System.Web.Mvc;
using GuitarCenter.Web.Mappings.Brands;
using GuitarCenter.Web.Models.Brands;

namespace GuitarCenter.Web.Areas.Administrations.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        private IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        public ActionResult Index()
        {
            BrandListPageViewModel model = new BrandListPageViewModel();
            FindAllBrandsResponse response = brandService.FindAllBrands();
            if (response.Success)
            {
                model.BrandViewModels = response.Brands.ConvertToBrandViewModelList();
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
            BrandSinglePageViewModel model = new BrandSinglePageViewModel();
            model.BrandViewModel = new BrandViewModel();
            model.Success = true;
            return View("Edit", model);
        }

        public ActionResult Edit(int brandId)
        {
            BrandSinglePageViewModel model = new BrandSinglePageViewModel();
            FindAllBrandsResponse response = brandService.FindAllBrands();
            if (response.Success)
            {
                model.BrandViewModel = response.Brands.
                    Where(x => x.BrandId == brandId).
                    FirstOrDefault().
                    ConvertToBrandViewModel();
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
        public ActionResult Edit(BrandSinglePageViewModel model)
        {
            if (model.BrandViewModel.BrandId == 0)
            {
                CreateBrandRequest request = new CreateBrandRequest();
                CreateBrandResponse response = new CreateBrandResponse();
                request.Name = model.BrandViewModel.Name;
                response = brandService.CreateBrand(request);
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
                UpdateBrandRequest request = new UpdateBrandRequest();
                UpdateBrandResponse response = new UpdateBrandResponse();
                request.BrandId = model.BrandViewModel.BrandId;
                request.Name = model.BrandViewModel.Name;
                response = brandService.UpdateBrand(request);
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

        public ActionResult Delete(int brandId)
        {
            DeleteBrandRequest request = new DeleteBrandRequest();
            DeleteBrandResponse response = new DeleteBrandResponse();
            request.BrandId = brandId;
            response = brandService.DeleteBrand(request);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                BrandListPageViewModel model = new BrandListPageViewModel();
                model.Success = false;
                model.ErrorMessage = response.Message;
                return View("Index", model);
            }
        }
    }
}
