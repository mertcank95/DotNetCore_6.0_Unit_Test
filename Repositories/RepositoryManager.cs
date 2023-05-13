using Repositories.Contracts;
using Repositories.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IOrderItemRepository> _orderItemRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _productRepository = new Lazy<IProductRepository>(
                () => new ProductRepository(_context));

            _orderItemRepository = new Lazy<IOrderItemRepository>(
                ()=> new OrderItemRepository(_context));
        }

        public IProductRepository Product => _productRepository.Value;

        public IOrderItemRepository OrderItem => _orderItemRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
