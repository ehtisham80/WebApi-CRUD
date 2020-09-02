using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_CRUD.Models;

namespace WebApi_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1006368,
                Name = "Austin and Barbque AABQ Wifi food thermometer",
                Description = "Thermometer med Wifi för an optimal innertemperatur",
                Price = 399
            },
            new Product
            {
                Id = 1009334,
                Name = "Anderson Electrisk Tändare ECL 1.1",
                Description = "Electrisk Stromsäker tändare helt utan gas och bränsle",
                Price = 89
            },
            new Product
            {
                Id = 1002266,
                Name = "Weber Non-Sticky Spray",
                Description = "BBQ-oljespray som motverkar att rävaror fastnar på gallret",
                Price = 99
            },
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = products.Find(p => p.Id == id);
            return product;
        }

        [HttpPost]
        public void Post ([FromBody] Product product)
        {
            products.Add(product);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = products.Where(p => p.Id == id);
            products = products.Except(product).ToList();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            var existingProduct = products.Where(p => p.Id == id);
            products = products.Except(existingProduct).ToList();

            products.Add(product);
        }


    }
}
