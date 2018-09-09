using GuitarCenter.AppService.Messages.Abstractions;
using GuitarCenter.Model.Entities.Products;
using System.Collections.Generic;

namespace GuitarCenter.AppService.Messages.Products
{
    public class FindAllProductsResponse : ResponseBase
    {
        public List<Product> Products { get; set; }
    }
}