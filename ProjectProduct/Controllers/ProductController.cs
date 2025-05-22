using Microsoft.AspNetCore.Mvc;
using ProductApiDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>();

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return product;
        }

        [HttpPost]
        public ActionResult<Product> Create(Product newProduct)
        {
            newProduct.Id = products.Count + 1;
            products.Add(newProduct);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }
    }
}
