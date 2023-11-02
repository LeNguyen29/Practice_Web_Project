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
    }
}
