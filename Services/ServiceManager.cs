using AutoMapper;
using Repositories.Contracts;
using Services.Contracts;
using Services.EntityServices;


namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IOrderItemService> _itemService;

        public ServiceManager(IRepositoryManager repository,IMapper mapper)
        {
            _productService =new Lazy<IProductService>(()=>
            new ProductManager(repository,mapper));

            _itemService = new Lazy<IOrderItemService>(()=>
            new OrderItemManager(repository,mapper));
        }

        public IProductService ProductService => _productService.Value;
        public IOrderItemService OrderItemService => _itemService.Value;
    }
}
