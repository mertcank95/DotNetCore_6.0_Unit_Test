using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetAllOrderItemsAsync();
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        Task<OrderItem> CreateOrderItemAsync(OrderItemDto orderItemDto);
        Task UpdateOrderItemAsync(int id, OrderItemDto orderItemDto);
        Task DeleteOrderItemAsync(int id);
    }
}
