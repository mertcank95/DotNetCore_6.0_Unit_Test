using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAllOrderItemsAsync();
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        void CreateOneOrderItem(OrderItem orderItem);
        void UpdateOneOrderItem(OrderItem orderItem);
        void DeleteOneOrderItem(OrderItem orderItem);
    }
}
