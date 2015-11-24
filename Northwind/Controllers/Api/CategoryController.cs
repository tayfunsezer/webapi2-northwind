using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Northwind.Controllers.Api
{
    public class CategoryController : ApiController
    {
        NorthwindEntities _entity;
        public CategoryController()
        {
            _entity = new NorthwindEntities();
            _entity.Configuration.ProxyCreationEnabled = false;
        }
        public List<Categories> GetAllCategories()
        {
            return _entity.Categories.OrderByDescending(p => p.CategoryID).ToList();
        }
        public Categories GetCategoriesByID(int id)
        {
            return _entity.Categories.SingleOrDefault(p => p.CategoryID == id);
        }
    }
}
