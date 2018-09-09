using GuitarCenter.AppService.Abstractions.Categories;
using GuitarCenter.AppService.Mappings.Categories;
using GuitarCenter.AppService.Messages.Categories;
using GuitarCenter.Model.Entities.Categories;
using System;

namespace GuitarCenter.AppService.Implementations.Categories
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public CreateCategoryResponse CreateCategory(CreateCategoryRequest request)
        {
            CreateCategoryResponse response = new CreateCategoryResponse();
            try
            {
                Category category = request.ConvertToCategory();
                categoryRepository.Create(category);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest request)
        {
            DeleteCategoryResponse response = new DeleteCategoryResponse();
            try
            {
                categoryRepository.Delete(request.CategoryId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public FindAllCategoriesResponse FindAllCategories()
        {
            FindAllCategoriesResponse response = new FindAllCategoriesResponse();
            try
            {
                response.Categories = categoryRepository.ReadAll();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest request)
        {
            UpdateCategoryResponse response = new UpdateCategoryResponse();
            try
            {
                Category category = request.ConvertToCategory();
                categoryRepository.Update(category);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
