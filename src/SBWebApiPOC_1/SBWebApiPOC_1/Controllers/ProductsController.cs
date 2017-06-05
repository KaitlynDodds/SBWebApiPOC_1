using SBWebApiPOC_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SBWebApiPOC_1.Controllers
{
    [Authorize]
    public class ProductsController : ApiController
    {

        Product[] products = new Product[]
            {
                new Product { Id = 1, Name = "Bread", Category = "Groceries", Price = 1.55M },
                new Product { Id = 2, Name = "Teddy Bear", Category = "Toys", Price = 9.99M },
                new Product { Id = 3, Name = "Pens", Category = "Supplies", Price = 15.99M },
                new Product { Id = 4, Name = "Fidget Spinner", Category = "Toys", Price = 7.99M },
                new Product { Id = 5, Name = "Pudding", Category = "Groceries", Price = 5.66M }
            };

        [Route("api/products")]
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        [Route("api/products/{id}")]
        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
