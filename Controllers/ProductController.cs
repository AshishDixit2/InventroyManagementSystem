/*using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}*/


using InventoryManagement.Implementations;
using InventoryManagement.Interfaces;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly IProduct _productRepository;
        public ProductController(IProduct productrepository)
        {
            _productRepository = productrepository;
        }

        [HttpGet("getAll")]
        public ICollection<ViewProduct> GetAllProducts()
        {
            return _productRepository.GetAllProduct();
        }

        [HttpGet("get/{id}")]
        public ViewProduct GetProduct(Guid id)
        {
            return _productRepository.GetProductById(id);
        }

        [HttpPut("add")]
        public Guid AddProduct([FromBody] PostProduct prod)
        {
            return _productRepository.AddProduct(prod);
        }

        [HttpDelete("delete")]
        public void DeleteProduct(Guid id)
        {
            _productRepository.DeleteProduct(id);
        }

        [HttpPatch("update/{id}")]
        public void UpdateProduct(Guid id, [FromBody] PostProduct prod)
        {
            _productRepository.UpdateProduct(id, prod);
        }
    }
}


/*
using InventoryManagement.Domain;
using InventoryManagement.Models;
using InventoryManagement.Reposits;
using InventoryManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
        [ApiController]
        [Route("products")]
        public class ProductController : Controller
        {
            private readonly IProduct _productRepository;
            public ProductController(IProduct productrepository)
            {
                _productRepository = productrepository;
            }

            [HttpGet("getAll")]
            public ICollection<ViewProduct> GetAllProducts()
            {
                return _productRepository.GetAllProduct();
            }

            [HttpGet("get/{id}")]
            public ViewProduct GetProduct(Guid id)
            {
                return _productRepository.GetProductById(id);
            }

            [HttpPut("add")]
            public Guid AddProduct([FromBody] PostProduct prod)
            {
                return _productRepository.AddProduct(prod);
            }

            [HttpDelete("delete")]
            public void DeleteProduct(Guid id)
            {
                _productRepository.DeleteProduct(id);
            }

            [HttpPatch("update/{id}")]
            public void UpdateProduct(Guid id, [FromBody] PostProduct prod)
            {
                _productRepository.UpdateProduct(id, prod);
            }
        }
 }
 */