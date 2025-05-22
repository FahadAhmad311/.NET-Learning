using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/products")]

public class ProductController : ControllerBase
{
    private static List<Product> products = new List<Product>();

    [HttpGet]
    public ActionResult<List<Product>> GetAll() => products;

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = products.FirstOrDefault(p => p.id == id);
        return product != null ? Ok(product) : NotFound();
    }

    [HttpPost]
    public ActionResult Create(Product newProduct)
    {
        newProduct.id = products.Count + 1;
        products.Add(newProduct);
        return Ok(newProduct);
    }
}
