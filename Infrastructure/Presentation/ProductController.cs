using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Shared;
namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]

        public async Task<IActionResult> GetAllProducts()
        {
            var result = await serviceManager.ProductService.GetAllProductsAsync();
            if (result is null) return BadRequest();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        { 
         var result= await serviceManager.ProductService.GetProductByIdAsync(id);
            if (result is null) return NotFound();
            return Ok(result);
        
        
        }
    }
}
