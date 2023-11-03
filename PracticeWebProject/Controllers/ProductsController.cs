using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeWebProject.Models;
using PracticeWebProject.Services;

namespace PracticeWebProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public JsonFileProductService ProductService { get; }

        public ProductsController(JsonFileProductService productService) 
        { 
            this.ProductService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return ProductService.GetProducts();
        }

        // [HttpPatch] update a tiny bit (get from body)
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery] string productId,
            [FromQuery] int rating
            )
        {
            ProductService.AddRating(productId, rating);

            return Ok();
        }
    }
}
