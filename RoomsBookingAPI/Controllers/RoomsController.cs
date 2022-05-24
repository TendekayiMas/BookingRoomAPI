using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomsBookingAPI.Data;
using RoomsBookingAPI.Models;
using RoomsBookingAPI.Services;

namespace RoomsBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly ICrudServices<TblRooms, int> _roomServices;
        public RoomsController(ICrudServices<TblRooms, int> roomService)
        {
            _roomServices = roomService;
        }
        [HttpGet("GetRooms")]
        public ActionResult<List<TblRooms>> GetAll() => _roomServices.GetAll().ToList();

        [HttpGet("Id")]
        public ActionResult<TblRooms> Get(int Id)
        {
            var rooms = _roomServices.Get(Id);
            if (rooms == null) return NotFound();
            else return rooms;
            
            
        }
        [HttpPost("CreateRoom")] // create a new room in database 

        public IActionResult Create(TblRooms rooms)  // the end user will pass this in the body of request 
        {
            if (ModelState.IsValid)
            {
                _roomServices.Add(rooms);
                return CreatedAtAction(nameof(Create), new { Id = rooms.Id }, rooms);
            }
            return BadRequest();
        }

        [HttpPut("UpdateRoom")] // update rooms in database 

        public IActionResult update(int id, TblRooms rooms)
        {
            var existingTblRooms = _roomServices.Get(id);
            if (existingTblRooms == null || existingTblRooms.Id != id){
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _roomServices.Update(existingTblRooms, rooms);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("DeleteRoom/{Id}")] // Delete a room in the database 

        public IActionResult Delete(int Id) // for delete should just pass in the ID 
        {
            var room = _roomServices.Get(Id);
            if(room == null) return NotFound();
            _roomServices.Delete(Id);
            return NoContent();
        }

      
        
       
    }
}
