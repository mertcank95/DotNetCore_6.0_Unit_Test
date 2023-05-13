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
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto product)
        {
            var enetity = _mapper.Map<Product>(product);
            _manager.Product.CreateOneProduct(enetity);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(enetity);
        }

        public async Task DeleteProductAsync(int id)
        {
            var entity = await GetProductId(id);
            _manager.Product.DeleteOneProduct(entity);
            await _manager.SaveAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _manager.Product.GetAllProductsAsync();
            return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await GetProductId(id);
            return product;
        }

        public async Task UpdateProductAsync(int id, ProductDto productDto)
        {
            var entity = await GetProductId(id);
            entity = _mapper.Map<Product>(productDto);
            _manager.Product.UpdateOneProduct(entity);
            await _manager.SaveAsync();
        }

        private async Task<Product> GetProductId(int id)
        {
            var entitiy = await _manager.Product.GetProductByIdAsync(id);
            if (entitiy is null)
                throw new Exception("product not found");
            return entitiy;
        }
    }

}
