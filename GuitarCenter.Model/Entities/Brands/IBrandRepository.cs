using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.Model.Entities.Brands
{
    public interface IBrandRepository
    {
        List<Brand> ReadAll();
        void Update(Brand entity);
        void Create(Brand entity);
        void Delete(int id);
    }
}