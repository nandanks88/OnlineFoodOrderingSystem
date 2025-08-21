using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.Controllers.Order
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class OrderController : ControllerBase
    {

        [HttpGet("secure")]
        [Authorize(Roles = "Customer")]
        public IActionResult GetSecureData()
        {
            return Ok("You accessed a protected endpoint!");
        }


        
        [Authorize(Roles = "Admin")]
        [HttpGet("secure-admin")]
        //[Authorize(Roles = "Chef")]
        public IActionResult OrderStatus()
        {
            return Ok("This is a admin page");
        }






    }
}
