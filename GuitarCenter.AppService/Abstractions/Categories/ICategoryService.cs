using GuitarCenter.AppService.Messages.Categories;

namespace GuitarCenter.AppService.Abstractions.Categories
{
    public interface ICategoryService
    {
        CreateCategoryResponse CreateCategory(CreateCategoryRequest request);
        FindAllCategoriesResponse FindAllCategories();
        UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest request);
        DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest request);

    }
}