using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;


namespace Repositories.EntityRepositories
{
    public sealed class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneOrderItem(OrderItem orderItem)
        {
           Create(orderItem);
        }

        public void DeleteOneOrderItem(OrderItem orderItem)
        {
            Delete(orderItem);
        }

        public async Task<List<OrderItem>> GetAllOrderItemsAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            return await GetByCondition(p => p.OrderItemId.Equals(id)).SingleOrDefaultAsync();

        }

        public void UpdateOneOrderItem(OrderItem orderItem)
        {
            Update(orderItem);
        }
    }
}
