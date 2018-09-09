using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.Model.Entities.Products
{
    public interface IProductRepository
    {
        List<Product> ReadAll();
        void Update(Product entity);
        void Create(Product entity);
        void Delete(int id);
    }
}