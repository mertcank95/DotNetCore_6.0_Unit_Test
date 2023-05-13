using Entities.DTO;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<ProductDto> CreateProductAsync(ProductDto product);
        Task UpdateProductAsync(int id,ProductDto product);
        Task DeleteProductAsync(int id);

    }
}
