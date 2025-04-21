using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Route.Store.Api.Controllers
{
    [ApiController]
    [Route( "api/[controller]")]
    public class BuggyController : ControllerBase
    {
        [HttpGet(template: "notfound")] // GET: /api/Buggy/notfound
        public IActionResult GetNotFoundRequest()
        {
            // Code
            return NotFound(); // 404
        }
        [HttpGet(template: "badrequest")] // GET: /api/Buggy/badrequest
        public IActionResult GetBadRequest()
        {
            // Code
            return BadRequest(); // 400
        }

        [HttpGet(template: "badrequest/{id}")] // GET: /api/Buggy/badrequest/nour
        public IActionResult GetBadRequest(int id) // Validation Error
        {
            // Code
            return BadRequest(); // 400
        }
        [HttpGet(template: "unauthorized")] // GET: /api/Buggy/unauthorized
        public IActionResult GetUnauthorizedRequest()
        {
            // Code
            return Unauthorized(); // 401
        }

    }
}
