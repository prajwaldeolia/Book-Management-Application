using ConsoleToWebAPI.Models;
using ConsoleToWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly ProductRepository _productRepository;        //normal
        private readonly IProductRepository _productRepository;         //dependency->sigleton
        private readonly IProductRepository _productRepository1;

        //public ProductController()                                    //old constructor normal wala
        //{
        //    _productRepository = new ProductRepository();
        //}

        public ProductController(IProductRepository productRepository, IProductRepository productRepository1)  //dependency->sigleton
        {
            _productRepository = productRepository;
            _productRepository1 = productRepository1;
        }

        [HttpPost("")]
        public IActionResult Addproduct([FromBody]ProductModel product)
        {
            _productRepository.AddProduct(product);
            var products = _productRepository1.GetAllProducts();

            return Ok(products);
        }

        [HttpGet("")]
        public IActionResult GetName()
        {
            var name = _productRepository.GetName();

            return Ok(name);
        }
    }
}
