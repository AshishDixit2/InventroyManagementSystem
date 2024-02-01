using InventoryManagement.Domain;
using InventoryManagement.DTO;
using InventoryManagement.Reposits;
using Microsoft.AspNetCore.Mvc;
using ProductManagementcommerce.Controllers;

namespace InventoryManagement.Controllers
{
    public class product1Controller : Controller
    {
        private readonly IRepository<Product> _repository;
        public product1Controller(IRepository<Product> repository)
            {
                _repository = repository;
            }

            [HttpPost]
            [Route("add")]
            public void AddProduct([FromBody] Modelclass updatedProduct)
            {
                var Modelclass = new Product()
                {
                    Name = updatedProduct.Name,
                    Quantity = updatedProduct.Quantity,
                    Measurement = updatedProduct.Measurement,
                    CategoryId = updatedProduct.CategoryId,
                };



                _repository.Add(Modelclass);

            }
        }
}

