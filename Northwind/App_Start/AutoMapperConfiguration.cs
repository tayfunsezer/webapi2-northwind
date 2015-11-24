using AutoMapper;
using Northwind.Models;
using Northwind.Models.PocoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.App_Start
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfile<ProductProfile>());
        }
    }

    public class ProductProfile : Profile
    {
        protected override void Configure()
        {
            // Configuration here
            CreateMap<Products, ProductPoco>();
        }
    }


}