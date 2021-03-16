using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OldProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product{Id = 1, Name = "Banana", Category = "Fruits"},
            new Product{Id = 2, Name = "Apple", Category = "Fruits"},
            new Product{Id = 3, Name = "Red Pepper", Category = "Vegetables"},
            new Product{Id = 4, Name = "Broccoli", Category = "Vegetables"},

        };

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _products.Where(x => x.Id == id).FirstOrDefault();
        }

        // GET: api/<ProductsController>/test
        [HttpGet("[action]/{name}")]
        public Product ByName(string name)
        {
            return _products.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _products.Add(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            var currentProduct = _products.Where(x => x.Id == id).FirstOrDefault();
            
            if (currentProduct != null)
            {
                currentProduct.Name = product.Name;
                currentProduct.Category = product.Category;

                return Ok();
            }
            else
            {
                return NotFound("Product not found");
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _products.Where(x => x.Id == id).FirstOrDefault();

            if (product != null)
            {
                _products.Remove(product);
                return Ok();
            }
            else
            {
                return NotFound("Product not found");
            }
        }
    }
}
