using InventoryManagement.Interfaces;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : Controller
    {
        private readonly IProductCategory _categoryRepository;
        public CategoryController(IProductCategory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("getAll")]
        public ICollection<ViewProductCategory> GetAllCategory()
        {
            return _categoryRepository.GetAllCategory();
        }

        [HttpGet("get/{id}")]
        public ViewProductCategory GetCategory(Guid id)
        {
            return _categoryRepository.GetCategory(id);
        }

        [HttpPost("add")]
        public Guid AddCategory(PostProductCategory category)
        {
            return _categoryRepository.AddCategory(category);
        }
    }
}






































/*using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    public class ProductCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}*/


/*using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Domain;
namespace Inventory.Controllers
{
    [ApiController]
    public class Product_Control : Controller
    {
        [HttpGet]
        [Route("get")]
        public string Index()
        {
            return "Product";
        }
        [HttpPost]
        [Route("create")]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            // Logic to create the product
            // For demonstration purposes, let's just return the product name
            return Ok($"Product '{product.Name}' created successfully.");
        }
    }
}

using InventoryManagement.Domain;
using InventoryManagement.DTO;
using InventoryManagement.Reposits;
using Microsoft.AspNetCore.Mvc;


namespace ProductManagementcommerce.Controllers

{

    [ApiController]
    [Route("Api/")]
    public class ProductController : Controller

    {

        private IRepository<ProductCategory> Repository;

        public ProductController(IRepository<ProductCategory> repository)

        {

            Repository = repository;

        }


        [HttpPost]

        [Route("Add/")]

        public IActionResult AddProduct([FromBody] ProductCategory updatedProduct)

        {

            try

            {

                if (updatedProduct == null)

                {

                    return BadRequest("Product data is null.");

                }

                Repository.Add(updatedProduct); // Assuming Id is the primary key

                //if (existingProduct == null)

                //{

                //    return NotFound($"Product with ID {updatedProduct.Id} not found.");

                //}

                //// Update properties based on the received data

                //existingProduct.Id = updatedProduct.Id;

                //existingProduct.Name = updatedProduct.Name;

                //// Assuming you have a method to update the entity in your repository

                //_productRepository.Update(existingProduct);

                return Ok("Product updated successfully.");

            }

            catch (Exception ex)

            {

                // Log the exception or handle it as needed

                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }
        [HttpGet]
        [Route("Get/{productId}")]
        public IActionResult GetProduct(int productId)
        {
            try
            {
                var product = Repository.GetById(productId);

                if (product == null)
                {
                    return NotFound($"Product with ID {productId} not found.");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete]
        [Route("Delete/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                var product = Repository.GetById(productId);

                if (product == null)
                {
                    return NotFound($"Product with ID {productId} not found.");
                }

                Repository.Delete(product);

                return Ok($"Product with ID {productId} deleted successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}


   */
