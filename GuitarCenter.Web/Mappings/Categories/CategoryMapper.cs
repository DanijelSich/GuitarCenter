using GuitarCenter.Model.Entities.Categories;
using GuitarCenter.Web.Models.Categories;
using System.Collections.Generic;

namespace GuitarCenter.Web.Mappings.Categories
{
    public static class CategoryMapper
    {
        public static List<CategoryViewModel> ConvertToCategoryViewModelList(this List<Category> categories)
        {
            List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();
            foreach (Category category in categories)
            {
                categoryViewModels.Add(category.ConvertToCategoryViewModel());
            }
            return categoryViewModels;
        }

        public static CategoryViewModel ConvertToCategoryViewModel(this Category category)
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.CategoryId = category.CategoryId;
            categoryViewModel.Name = category.Name;

            return categoryViewModel;
        }
    }
}