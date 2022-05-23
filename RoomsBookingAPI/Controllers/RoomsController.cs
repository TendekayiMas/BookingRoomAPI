using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoomsBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        [HttpGet("GetRooms")]
        public IActionResult Get()
        {
            return Ok(); // return an ok result of 200 for now 
        }
        [HttpPost("CreateRoom")]

        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPut("UpdateRoom")]

        public IActionResult update()
        {
            return Ok();
        }

        [HttpDelete("DeleteRoom")]

        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
