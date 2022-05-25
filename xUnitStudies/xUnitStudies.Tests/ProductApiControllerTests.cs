using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using xUnitStudies.Web.Controllers;
using xUnitStudies.Web.Models;
using xUnitStudies.Web.Repository;

namespace xUnitStudies.Tests
{
    public class ProductApiControllerTests
    {
        private readonly Mock<IRepository<Product>> _mockRepo;
        private readonly ProductsApiController _controller;

        private List<Product> _products;

        public ProductApiControllerTests()
        {
            _mockRepo = new Mock<IRepository<Product>>();
            _controller = new ProductsApiController(_mockRepo.Object); ;

            _products = new List<Product>
            {
                new Product{ Id = 1, Name ="Kalem",Color="Kırmızı",Price=100},
                new Product{ Id = 2, Name ="Öanta",Color="Siyah",Price=500},
            };
        }

        [Fact]
        public async void GetProduct_ActionExecutes_ReturnOkResultWithProduct()
        {
            _mockRepo.Setup(x => x.GetAll()).ReturnsAsync(_products);

            var result = await _controller.GetProduct();

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnProducts = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);

            Assert.Equal<int>(2, returnProducts.ToList().Count);
        }

        [Theory]
        [InlineData(0)]
        public async void GetProduct_IdInValid_ReturnNotFound(int productId)
        {
            Product product = null;

            _mockRepo.Setup(x => x.GetById(productId)).ReturnsAsync(product);

            var result = await _controller.GetProduct(productId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void GetProduct_IdValid_ReturnOkResult(int productId)
        {
            var product = _products.First(x => x.Id == productId);

            _mockRepo.Setup(x => x.GetById(productId)).ReturnsAsync(product);

            var result = await _controller.GetProduct(productId);

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnProduct = Assert.IsType<Product>(okResult.Value);

            Assert.Equal(productId, returnProduct.Id);
            Assert.Equal(product.Name, returnProduct.Name);
        }
    }
}
