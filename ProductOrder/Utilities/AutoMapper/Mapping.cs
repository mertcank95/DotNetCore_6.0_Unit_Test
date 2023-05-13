using AutoMapper;
using Entities.DTO;
using Entities.Models;

namespace ProductOrder.Utilities.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<OrderItem,OrderItemDto>().ReverseMap();

        }
    }
}
