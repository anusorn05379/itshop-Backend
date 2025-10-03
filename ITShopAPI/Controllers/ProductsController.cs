using Microsoft.AspNetCore.Mvc;
using ITShopAPI.DTOs;
using ITShopAPI.Services;

namespace ITShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 50)
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();

                var totalCount = products.Count();
                var paginatedProducts = products
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                Response.Headers.Append("X-Total-Count", totalCount.ToString());
                Response.Headers.Append("X-Page", page.ToString());
                Response.Headers.Append("X-Page-Size", pageSize.ToString());

                return Ok(paginatedProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving products");
                return StatusCode(500, "An error occurred while retrieving products");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                    return NotFound($"Product with ID {id} not found");

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving product {ProductId}", id);
                return StatusCode(500, "An error occurred while retrieving the product");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto productDto)
        {
            try
            {
                var product = await _productService.CreateProductAsync(productDto);
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product");
                return StatusCode(500, "An error occurred while creating the product");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update(int id, [FromBody] UpdateProductDto productDto)
        {
            try
            {
                var product = await _productService.UpdateProductAsync(id, productDto);
                if (product == null)
                    return NotFound($"Product with ID {id} not found");

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product {ProductId}", id);
                return StatusCode(500, "An error occurred while updating the product");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _productService.DeleteProductAsync(id);
                if (!result)
                    return NotFound($"Product with ID {id} not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product {ProductId}", id);
                return StatusCode(500, "An error occurred while deleting the product");
            }
        }

        [HttpGet("{id}/check-stock")]
        public async Task<ActionResult<bool>> CheckStock(int id, [FromQuery] int quantity)
        {
            try
            {
                var available = await _productService.CheckStockAvailability(id, quantity);
                return Ok(new { available });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking stock for product {ProductId}", id);
                return StatusCode(500, "An error occurred while checking stock");
            }
        }
    }
}
