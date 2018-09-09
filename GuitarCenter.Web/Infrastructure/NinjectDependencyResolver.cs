using Ninject;
using GuitarCenter.AppService.Abstractions.Brands;
using GuitarCenter.AppService.Abstractions.Categories;
using GuitarCenter.AppService.Abstractions.Products;
using GuitarCenter.AppService.Abstractions.Users;
using GuitarCenter.AppService.Implementations.Brands;
using GuitarCenter.AppService.Implementations.Categories;
using GuitarCenter.AppService.Implementations.Products;
using GuitarCenter.AppService.Implementations.Users;
using GuitarCenter.Model.Entities.Brands;
using GuitarCenter.Model.Entities.Categories;
using GuitarCenter.Model.Entities.Products;
using GuitarCenter.Model.Entities.Users;
using GuitarCenter.Repository.Brands;
using GuitarCenter.Repository.Categories;
using GuitarCenter.Repository.Products;
using GuitarCenter.Repository.Users;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GuitarCenter.Web.Infrastructure
{
    class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<IProductService>().To<ProductService>();

            kernel.Bind<IBrandRepository>().To<BrandRepository>();
            kernel.Bind<IBrandService>().To<BrandService>();

            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<ICategoryService>().To<CategoryService>();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IUserService>().To<UserService>();
        }
    }
}