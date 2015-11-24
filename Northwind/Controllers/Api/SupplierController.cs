using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Northwind.Controllers.Api
{
    public class SupplierController : ApiController
    {
        NorthwindEntities _entity;
        public SupplierController()
        {
            _entity = new NorthwindEntities();
            _entity.Configuration.ProxyCreationEnabled = false;
        }

        public List<Suppliers> GetAllSuppliers()
        {
            return _entity.Suppliers.OrderByDescending(p => p.SupplierID).ToList();
        }

        public Suppliers GetSuppliersByID(int id)
        {
            return _entity.Suppliers.SingleOrDefault(p => p.SupplierID == id);
        }
    }
}
