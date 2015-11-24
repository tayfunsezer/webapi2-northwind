using AutoMapper;
using Northwind.Models;
using Northwind.Models.PocoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Northwind.Controllers.Api
{
    public class ProductController : ApiController
    {
        NorthwindEntities _entity;
        //convention based.
        public ProductController()
        {
            _entity = new NorthwindEntities();
            _entity.Configuration.ProxyCreationEnabled = false;
        }
        //Response to request that made with GET method and no parameter.
        public List<Products> GetAllProducts()
        {
            return _entity.Products.OrderByDescending(p => p.ProductID).ToList();
        }

        //Response to request that made with GET method and id parameter
        public IHttpActionResult GetProductByID(int id)
        {
            var productObject = GetProduct(id);
            if (productObject == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }
            var product = Mapper.Map<ProductPoco>(productObject);
            return Content(HttpStatusCode.OK, product);
        }

        //Response to request that made with DELETE method
        public IHttpActionResult DeleteProduct(int id)
        {
            var productObject = GetProduct(id);
            if (productObject == null)
            {
                return Content(HttpStatusCode.NotFound, "");
            }
            _entity.Products.Remove(productObject);
            _entity.SaveChanges();
            return Content(HttpStatusCode.OK, "");
        }

        //response to request that made with POST method and id parameter
        //edit product
        public IHttpActionResult PostProduct(int id, [FromBody] ProductPoco p)
        {
            var product = GetProduct(id);
            product.ProductName = p.ProductName;
            product.UnitPrice = p.UnitPrice;
            product.CategoryID = p.CategoryID;
            product.SupplierID = p.SupplierID;
            _entity.SaveChanges();
            return Content(HttpStatusCode.OK, "");
        }

        //response to request that made with POST method and no parameter
        //insert product
        public IHttpActionResult PostProduct([FromBody] ProductPoco p)
        {

            _entity.Products.Add(Mapper.Map<Products>(p));
            _entity.SaveChanges();
            return Content(HttpStatusCode.OK, p.ProductID);
        }

        #region model
        private Products GetProduct(int id)
        {
            return _entity.Products.SingleOrDefault(p => p.ProductID == id);
        }
        #endregion
    }
}
