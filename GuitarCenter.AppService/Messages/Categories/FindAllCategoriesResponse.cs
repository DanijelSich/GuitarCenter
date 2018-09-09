using GuitarCenter.AppService.Messages.Abstractions;
using GuitarCenter.Model.Entities.Categories;
using System.Collections.Generic;

namespace GuitarCenter.AppService.Messages.Categories
{
    public class FindAllCategoriesResponse : ResponseBase
    {
        public List<Category> Categories { get; set; }
    }
}