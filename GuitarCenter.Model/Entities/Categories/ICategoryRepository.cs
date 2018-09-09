using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.Model.Entities.Categories
{
    public interface ICategoryRepository
    {
        List<Category> ReadAll();
        void Update(Category entity);
        void Create(Category entity);
        void Delete(int id);
    }
}