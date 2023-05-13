using AutoMapper;
using Castle.Components.DictionaryAdapter;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Controller;
using ProductOrder.Utilities.AutoMapper;
using Services.Contracts;
using System.Collections.Generic;
using System.Net;

namespace OrderProduct_UnitTest
{
    public class UnitTest
    {
        private readonly Mock<IServiceManager> _serviceManagerMock;
        private readonly IMapper _mapper;
        public UnitTest()
        {
            _serviceManagerMock = new Mock<IServiceManager>();
            if(_mapper is null )
            {
                var mappingConfigure = new MapperConfiguration(map =>
                {
                    map.AddProfile(new Mapping());
                });
                IMapper mapper = mappingConfigure.CreateMapper();
                _mapper = mapper;
            }
        }


        [Fact]
        public void CreateProduct_Test()
        {
            //arrange
            var productDto = new ProductDto
            {
                Name = "Test Product",
                StockQuantity = 10
            };
            _serviceManagerMock.Setup(x => x.ProductService.CreateProductAsync(productDto))
                .ReturnsAsync(productDto);
            var productController = new ProductController(_serviceManagerMock.Object);
            //act
            var productResult = productController.CreateProduct(productDto);
            var okResult = Assert.IsType<OkObjectResult>(productResult.Result);
            var createdProduct = Assert.IsType<ProductDto>(okResult.Value);
            //assert
            Assert.NotNull(productResult);
            Assert.Equal(productDto.Name, createdProduct.Name);
            Assert.IsType<OkObjectResult>(productResult.Result);
        }

        [Fact]
        public  void GetAllAsyncProduct_Test()
        {
            //Arrange
            List<Product> productList = GetProducts();
            _serviceManagerMock.Setup(x => x.ProductService.GetAllProductsAsync())
                 .ReturnsAsync(productList);
            var productController = new ProductController(_serviceManagerMock.Object);
            //Act
            var productResult = productController.GetAllProducts();
            var productListResult = Assert.IsType<List<Product>>(productResult.Result);
            //Assert
            Assert.NotNull(productResult);
            Assert.Equal(productListResult.Count(), productList.Count());
            Assert.Equal(productListResult[0].Id, productList[0].Id);
        }

        [Theory]
        [MemberData(nameof(GetProductIds))]
        public async void GetProductByID_Test(int id)
        {
            //Arrange
            var productList = GetProducts();
            _serviceManagerMock.Setup(x => x.ProductService.GetProductByIdAsync(id))
                 .ReturnsAsync(productList[id-1]);
            var productController = new ProductController(_serviceManagerMock.Object);
            //Act
            var productResult = await productController.GetOneProductAsync(id);
            var okResult = Assert.IsType<OkObjectResult>(productResult);
            var product = Assert.IsType<Product>(okResult.Value);
            //assert
            Assert.NotNull(productResult);
            Assert.Equal(productList[id-1].Id, product.Id);
            Assert.True(product.Id > 0);
        }

        [Fact]
        public async void DeleteProductById_Test()
        {
            int id = 1;
            List<Product> productList = GetProducts();
            _serviceManagerMock.Setup(x => x.ProductService.GetAllProductsAsync())
                 .ReturnsAsync(productList);
            _serviceManagerMock.Setup(x => x.ProductService.DeleteProductAsync(id)).Returns(Task.CompletedTask);
            var productController = new ProductController(_serviceManagerMock.Object);
            // Act
             var result = await productController.DeleteOneProduct(id) ;
             var okResult = Assert.IsType<NoContentResult>(result);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(204, okResult.StatusCode);
        }
 


       

        List<Product> GetProducts()
        {
             List<Product> productList = new List<Product> {
                new Product { Id=1, Name = "Test 1", StockQuantity = 7 },
                new Product { Id=2,Name = "Test 2", StockQuantity = 5 }
            };
            return productList;
        }

        public static IEnumerable<object[]> GetProductIds()
        {
            yield return new object[] { 1 };
            yield return new object[] { 2 };
        }



    }
}