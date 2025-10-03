using Microsoft.AspNetCore.Mvc;
using ITShopAPI.DTOs;
using ITShopAPI.Services;

namespace ITShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                if (order == null)
                    return NotFound($"Order with ID {id} not found");

                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order {OrderId}", id);
                return StatusCode(500, "An error occurred while retrieving the order");
            }
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetByCustomerId(int customerId)
        {
            try
            {
                var orders = await _orderService.GetOrdersByCustomerIdAsync(customerId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders for customer {CustomerId}", customerId);
                return StatusCode(500, "An error occurred while retrieving orders");
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> Create([FromBody] CreateOrderDto orderDto)
        {
            try
            {
                var order = await _orderService.CreateOrderAsync(orderDto);
                return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order");
                return StatusCode(500, "An error occurred while creating the order");
            }
        }

        [HttpPost("{id}/confirm-payment")]
        public async Task<ActionResult<OrderDto>> ConfirmPayment(int id)
        {
            try
            {
                var order = await _orderService.ConfirmPaymentAsync(id);
                return Ok(order);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error confirming payment for order {OrderId}", id);
                return StatusCode(500, "An error occurred while confirming payment");
            }
        }

        [HttpPost("{id}/cancel")]
        public async Task<ActionResult> Cancel(int id)
        {
            try
            {
                var result = await _orderService.CancelOrderAsync(id);
                if (!result)
                    return NotFound($"Order with ID {id} not found");

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling order {OrderId}", id);
                return StatusCode(500, "An error occurred while cancelling the order");
            }
        }
    }
}
