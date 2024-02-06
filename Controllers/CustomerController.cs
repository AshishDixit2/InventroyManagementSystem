using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Interfaces;

namespace InventoryManagement.Controllers
{
    
        [ApiController]
        [Route("customers")]
        public class CustomerController : Controller
        {
            private readonly ICustomer _customerService;
            public CustomerController(ICustomer customerService)
            {
                _customerService = customerService;
            }
            [HttpGet("getDetails/{id}")]
            public ViewCustomer GetAllDetails(Guid id)
            {
                return _customerService.GetOrdersByCustomers(id);
            }

            [HttpPost("add")]
            public Guid AddCustomer(PostCustomer customer)
            {
                return _customerService.AddCustomer(customer);
            }

            [HttpDelete("delete/{id}")]
            public void DeleteCustomer(Guid id)
            {
                _customerService.DeleteCustomer(id);
            }

            [HttpPatch("update/{id}")]
            public void UpdateCustomer(Guid id, PostCustomer customer)
            {
                _customerService.UpdateCustomer(id, customer);
            }
        }
    }

