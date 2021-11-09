using E_shop.Models;
using E_shop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace E_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
    [HttpPost("Create")]
        public IActionResult Create(Product product)
        {
            if(product.ProductName == "")
            {
                return ValidationProblem("Nenurodėte produkto pavadinimo!");
            }
            if(product.Id == "")
            {
                return ValidationProblem("Nenurodėte producto ID!");
            }
            if (product.ProductDescription == "")
            {
                return ValidationProblem("Nenurodėte produkto aprašymo!");
            }
            if (product.StartPrice == 0)
            {
                return ValidationProblem("Nenurodėte produkto kainos!");
            }

            var service = new ProductService();

            service.CreateProduct(product);

            return Ok();
        }

        [HttpGet("list")]

        public IActionResult List()
        {
            var service = new ProductService();

            var products = service.GetProducts();

            return new OkObjectResult(products);
        }

        [HttpGet]

        public IActionResult Get(string id)
        {
            var service = new ProductService();

            var product = service.GetProduct(id);

            return new OkObjectResult(product);
        }

        [HttpGet("filter")]

        public IActionResult Filter(string text)
        {
            var service = new ProductService();

            var products = service.GetProducts();

            var filteredProducts = new List<Product>();
            foreach(var product in products)
            {
                if (product.GetInformation().Contains(text))
                {
                    filteredProducts.Add(product);
                }
            }
            return new OkObjectResult(filteredProducts);
        }
    }
}
