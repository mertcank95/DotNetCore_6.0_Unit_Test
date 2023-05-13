using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IServiceManager _service;

        public OrderItemController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] OrderItemDto orderItemDto)
        {
            var orderItem = await _service.OrderItemService.CreateOrderItemAsync(orderItemDto);
            return StatusCode(201, orderItem);
        }

        [HttpGet]
        public async Task<List<OrderItem>> GetOrderItem()
        {
            return await _service.OrderItemService.GetAllOrderItemsAsync();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem([FromRoute] int id)
        {
            await _service.OrderItemService.DeleteOrderItemAsync(id);
            return NoContent();
        }
    }
}
