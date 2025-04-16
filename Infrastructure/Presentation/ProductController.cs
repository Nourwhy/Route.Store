using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Shared;
namespace Route.Store.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery]ProductSpecificationPramaeters pramaeters)
        {
            var result = await _serviceManager.ProductService.GetAllProductsAsync(pramaeters);
            if (result is null) return BadRequest();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _serviceManager.ProductService.GetProductByIdAsync(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetAllBrands()
        {
            var result = await _serviceManager.ProductService.GetAllBrandsAsync();
            if (result is null) return BadRequest();
            return Ok(result);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await _serviceManager.ProductService.GetAllTypeAsync();
            if (result is null) return BadRequest();
            return Ok(result);
        }
    }

}
