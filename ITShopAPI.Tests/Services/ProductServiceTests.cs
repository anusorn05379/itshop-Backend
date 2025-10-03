using Xunit;
using Moq;
using FluentAssertions;
using ITShopAPI.Services;
using ITShopAPI.Repositories;
using ITShopAPI.Models;
using ITShopAPI.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITShopAPI.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IRepository<Product>> _mockRepository;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _mockRepository = new Mock<IRepository<Product>>();
            _service = new ProductService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 100, Stock = 10, Description = "Test", ImageUrl = "test.jpg" },
                new Product { Id = 2, Name = "Product 2", Price = 200, Stock = 20, Description = "Test2", ImageUrl = "test2.jpg" }
            };
            _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(products);

            var result = await _service.GetAllProductsAsync();

            result.Should().HaveCount(2);
            result.First().Name.Should().Be("Product 1");
            _mockRepository.Verify(r => r.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetProductByIdAsync_WhenProductExists_ShouldReturnProduct()
        {
            var product = new Product
            {
                Id = 1,
                Name = "Test Product",
                Price = 150,
                Stock = 5,
                Description = "Description",
                ImageUrl = "image.jpg"
            };
            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(product);

            var result = await _service.GetProductByIdAsync(1);

            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.Name.Should().Be("Test Product");
            result.Price.Should().Be(150);
        }

        [Fact]
        public async Task GetProductByIdAsync_WhenProductNotExists_ShouldReturnNull()
        {
            _mockRepository.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Product)null);

            var result = await _service.GetProductByIdAsync(999);

            result.Should().BeNull();
        }

        [Fact]
        public async Task CreateProductAsync_ShouldCreateAndReturnProduct()
        {
            var createDto = new CreateProductDto
            {
                Name = "New Product",
                Description = "New Description",
                Price = 300,
                Stock = 15,
                ImageUrl = "new.jpg"
            };

            var createdProduct = new Product
            {
                Id = 3,
                Name = createDto.Name,
                Description = createDto.Description,
                Price = createDto.Price,
                Stock = createDto.Stock,
                ImageUrl = createDto.ImageUrl
            };

            _mockRepository.Setup(r => r.AddAsync(It.IsAny<Product>()))
                .ReturnsAsync(createdProduct);

            var result = await _service.CreateProductAsync(createDto);

            result.Should().NotBeNull();
            result.Id.Should().Be(3);
            result.Name.Should().Be("New Product");
            result.Price.Should().Be(300);
            result.Stock.Should().Be(15);
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task UpdateProductAsync_WhenProductExists_ShouldUpdateAndReturnProduct()
        {
            var existingProduct = new Product
            {
                Id = 1,
                Name = "Old Name",
                Description = "Old Description",
                Price = 100,
                Stock = 10,
                ImageUrl = "old.jpg"
            };

            var updateDto = new UpdateProductDto
            {
                Name = "Updated Name",
                Description = "Updated Description",
                Price = 250,
                Stock = 25,
                ImageUrl = "updated.jpg"
            };

            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingProduct);
            _mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            var result = await _service.UpdateProductAsync(1, updateDto);

            result.Should().NotBeNull();
            result.Name.Should().Be("Updated Name");
            result.Price.Should().Be(250);
            result.Stock.Should().Be(25);
            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task UpdateProductAsync_WhenProductNotExists_ShouldReturnNull()
        {
            var updateDto = new UpdateProductDto
            {
                Name = "Updated Name",
                Description = "Updated Description",
                Price = 250,
                Stock = 25,
                ImageUrl = "updated.jpg"
            };

            _mockRepository.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Product)null);

            var result = await _service.UpdateProductAsync(999, updateDto);

            result.Should().BeNull();
            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public async Task DeleteProductAsync_WhenProductExists_ShouldReturnTrue()
        {
            var product = new Product { Id = 1, Name = "Test", Price = 100, Stock = 10 };
            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(product);
            _mockRepository.Setup(r => r.DeleteAsync(product)).Returns(Task.CompletedTask);

            var result = await _service.DeleteProductAsync(1);

            result.Should().BeTrue();
            _mockRepository.Verify(r => r.DeleteAsync(product), Times.Once);
        }

        [Fact]
        public async Task DeleteProductAsync_WhenProductNotExists_ShouldReturnFalse()
        {
            _mockRepository.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Product)null);

            var result = await _service.DeleteProductAsync(999);

            result.Should().BeFalse();
            _mockRepository.Verify(r => r.DeleteAsync(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public async Task CheckStockAvailability_WhenStockSufficient_ShouldReturnTrue()
        {
            var product = new Product { Id = 1, Name = "Test", Price = 100, Stock = 10 };
            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(product);

            var result = await _service.CheckStockAvailability(1, 5);

            result.Should().BeTrue();
        }

        [Fact]
        public async Task CheckStockAvailability_WhenStockInsufficient_ShouldReturnFalse()
        {
            var product = new Product { Id = 1, Name = "Test", Price = 100, Stock = 10 };
            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(product);

            var result = await _service.CheckStockAvailability(1, 15);

            result.Should().BeFalse();
        }

        [Fact]
        public async Task CheckStockAvailability_WhenProductNotExists_ShouldReturnFalse()
        {
            _mockRepository.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Product)null);

            var result = await _service.CheckStockAvailability(999, 5);

            result.Should().BeFalse();
        }
    }
}
