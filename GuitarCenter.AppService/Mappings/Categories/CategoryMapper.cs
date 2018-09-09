using GuitarCenter.AppService.Messages.Categories;
using GuitarCenter.Model.Entities.Categories;

namespace GuitarCenter.AppService.Mappings.Categories
{
    public static class CategoryMapper
    {
        public static Category ConvertToCategory(this CreateCategoryRequest createRequest)
        {
            Category category = new Category();
            category.Name = createRequest.Name;

            return category;
        }

        public static Category ConvertToCategory(this UpdateCategoryRequest updateRequest)
        {
            Category category = new Category();
            category.CategoryId = updateRequest.CategoryId;
            category.Name = updateRequest.Name;

            return category;
        }
    }
}