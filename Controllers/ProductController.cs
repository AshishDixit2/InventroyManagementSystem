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
}*/

using InventoryManagement.Domain;
using InventoryManagement.Reposits;
using Microsoft.AspNetCore.Mvc;
 
namespace ProductManagementcommerce.Controllers

{

    [ApiController]

    public class ProductController : Controller

    {

        private IRepository<ProductCategory> Repository;

        public ProductController(IRepository<ProductCategory> repository)

        {

            Repository = repository;

        }


        [HttpPost]

        [Route("Add")]

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

    }

}
