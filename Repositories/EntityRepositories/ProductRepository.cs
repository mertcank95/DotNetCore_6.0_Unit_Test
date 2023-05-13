using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EntityRepositories
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product)
        {
            Create(product);
        }

        public void DeleteOneProduct(Product product)
        {
            Delete(product);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await GetByCondition(p => p.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public void UpdateOneProduct(Product product)
        {
            Update(product);
        }
    }
}
