using AutoMapper;
using Entities.DTO;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EntityServices
{
    public class OrderItemManager : IOrderItemService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public OrderItemManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        public async Task<OrderItem> CreateOrderItemAsync(OrderItemDto orderItemDto)
        {
            var enetity = _mapper.Map<OrderItem>(orderItemDto);
            _manager.OrderItem.CreateOneOrderItem(enetity);
            await _manager.SaveAsync();
            return _mapper.Map<OrderItem>(enetity);
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            var entity = await GetOrderById(id);
            _manager.OrderItem.DeleteOneOrderItem(entity);
            await _manager.SaveAsync();

        }

        public async Task<List<OrderItem>> GetAllOrderItemsAsync()
        {
            var products = await _manager.OrderItem.GetAllOrderItemsAsync();
            return products;
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            var orderItem = await GetOrderById(id);
            return orderItem;
        }

        public async Task UpdateOrderItemAsync(int id, OrderItemDto orderItemDto)
        {
            var entity = await GetOrderById(id);
            entity = _mapper.Map<OrderItem>(orderItemDto);
            _manager.OrderItem.UpdateOneOrderItem(entity);
            await _manager.SaveAsync();
        }

        

        private async Task<OrderItem> GetOrderById(int id)
        {
            var entitiy = await _manager.OrderItem.GetOrderItemByIdAsync(id);
            if (entitiy is null)
                throw new Exception("product not found");
            return entitiy;
        }



    }
}
