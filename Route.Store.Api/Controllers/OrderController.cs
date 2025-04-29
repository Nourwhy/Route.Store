using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using System.Security.Claims;

namespace Route.Store.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpPost] // POST: /api/Orders
        public async Task<ActionResult> CreateOrder(OrderRequestDto request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var result = await serviceManager.OrderService.CreateOrderAsync(request, email);
            return Ok(result);
        }
        [HttpGet] // GET: /api/Orders
        public async Task<ActionResult> GetOrders()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var result = await serviceManager.OrderService.GetOrdersByUserEmailAsync(email);
            return Ok(result);
        }

        [HttpGet("{id}")] // GET: /api/Orders/dasdas
        public async Task<ActionResult> GetOrderById(Guid id)
        {
            var result = await serviceManager.OrderService.GetOrderByIdAsync(id);
            return Ok(result);
        }
        [HttpGet("DeliveryMethods")] // GET: /api/Orders/DeliveryMethods
        public async Task<ActionResult> GetAllDeliveryMethods()
        {
            var result = await serviceManager.OrderService.GetAllDeliveryMethods();
            return Ok(result);
        }
    }
}
