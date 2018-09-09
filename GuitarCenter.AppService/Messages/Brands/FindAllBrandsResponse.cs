using System;
using System.Collections.Generic;
using GuitarCenter.AppService.Messages.Abstractions;
using GuitarCenter.Model.Entities.Brands;
using System.Threading.Tasks;

namespace GuitarCenter.AppService.Messages.Brands
{
    public class FindAllBrandsResponse : ResponseBase
    {
        public List<Brand> Brands { get; set; }
    }
}