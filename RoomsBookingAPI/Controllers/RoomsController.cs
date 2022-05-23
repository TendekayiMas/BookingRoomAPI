using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomsBookingAPI.Models;

namespace RoomsBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        [HttpGet("GetRooms")]
        public IActionResult Get()
        {
            var Rooms = GetRooms();
            return Ok(Rooms); // return an ok result of 200 for now 
        }
        [HttpPost("CreateRoom")] // create a new room in database 

        public IActionResult Create([FromBody] RequestRoom request)  // the end user will pass this in the body of request 
        {
            return Ok();
        }

        [HttpPut("UpdateRoom")] // update rooms in database 

        public IActionResult update([FromBody] RequestRoom request)
        {
            return Ok();
        }

        [HttpDelete("DeleteRoom/{Id}")] // Delete a room in the database 

        public IActionResult Delete(int Id) // for delete should just pass in the ID 
        {
            return Ok();
        }

        private List<RequestRoom> GetRooms()
        {
            return new List<RequestRoom>{
                new RequestRoom { RoomNumber = 55, RoomAvailability = true, RoomPrice = 400, RoomType = "penthouse" },
                new RequestRoom { RoomNumber = 35, RoomAvailability = true, RoomPrice = 400, RoomType = "penthouse" }
            };
        }
       
    }
}
