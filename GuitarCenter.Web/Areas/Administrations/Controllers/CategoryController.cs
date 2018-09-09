using GuitarCenter.AppService.Abstractions.Categories;
using GuitarCenter.AppService.Messages.Categories;
using GuitarCenter.Web.Areas.Administrations.Models;
using GuitarCenter.Web.Mappings.Categories;
using GuitarCenter.Web.Models.Categories;
using System.Linq;
using System.Web.Mvc;

namespace GuitarCenter.Web.Areas.Administrations.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            CategoryListPageViewModel model = new CategoryListPageViewModel();
            FindAllCategoriesResponse response = categoryService.FindAllCategories();
            if (response.Success)
            {
                model.CategoryViewModels = response.Categories.ConvertToCategoryViewModelList();
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
            CategorySinglePageViewModel model = new CategorySinglePageViewModel();
            model.CategoryViewModel = new CategoryViewModel();
            model.Success = true;
            return View("Edit", model);
        }

        public ActionResult Edit(int categoryId)
        {
            CategorySinglePageViewModel model = new CategorySinglePageViewModel();
            FindAllCategoriesResponse response = categoryService.FindAllCategories();
            if (response.Success)
            {
                model.CategoryViewModel = response.Categories.
                    Where(x => x.CategoryId == categoryId).
                    FirstOrDefault().
                    ConvertToCategoryViewModel();
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
        public ActionResult Edit(CategorySinglePageViewModel model)
        {
            if (model.CategoryViewModel.CategoryId == 0)
            {
                CreateCategoryRequest request = new CreateCategoryRequest();
                CreateCategoryResponse response = new CreateCategoryResponse();
                request.Name = model.CategoryViewModel.Name;
                response = categoryService.CreateCategory(request);
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
                UpdateCategoryRequest request = new UpdateCategoryRequest();
                UpdateCategoryResponse response = new UpdateCategoryResponse();
                request.CategoryId = model.CategoryViewModel.CategoryId;
                request.Name = model.CategoryViewModel.Name;
                response = categoryService.UpdateCategory(request);
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

        public ActionResult Delete(int categoryId)
        {
            DeleteCategoryRequest request = new DeleteCategoryRequest();
            DeleteCategoryResponse response = new DeleteCategoryResponse();
            request.CategoryId = categoryId;
            response = categoryService.DeleteCategory(request);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                CategoryListPageViewModel model = new CategoryListPageViewModel();
                model.Success = false;
                model.ErrorMessage = response.Message;
                return View("Index", model);
            }
        }
    }
}
