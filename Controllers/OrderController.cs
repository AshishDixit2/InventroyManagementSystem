
using InventoryManagement.Interfaces;
using InventoryManagement.Filters;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : Controller
    {
        private readonly IOrder _orderRepository;
        public OrderController(IOrder orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost("add")]
        [InventoryCheckFilter]
        public Guid AddOrder([FromBody] PostOrder postOrder)
        {
            return _orderRepository.AddOrder(postOrder);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteOrder(Guid id)
        {
            _orderRepository.DeleteOrder(id);
        }
    }
}

