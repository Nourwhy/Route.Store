using Microsoft.AspNetCore.Mvc;
using Service;
using Services.Abstractions;
using Shared;

namespace Route.Store.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketsController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet("{id}")] // GET: api/baskets/{id}
        public async Task<ActionResult<BasketDto>> GetBasketById(string id)
        {
            var result = await serviceManager.BasketService.GetBasketAsync(id);
            return Ok(result);
        }

        [HttpPost] // POST: api/baskets
        public async Task<ActionResult<BasketDto>> UpdateBasket(BasketDto basketDto)
        {
            var result = await serviceManager.BasketService.UpdateBasketAsync(basketDto);
            return Ok(result);
        }

        [HttpDelete("{id}")] // DELETE: api/baskets/{id}
        public async Task<IActionResult> DeleteBasket(string id)
        {
            await serviceManager.BasketService.DeleteBasketAsync(id);
            return NoContent(); // 204
        }
    }
}
