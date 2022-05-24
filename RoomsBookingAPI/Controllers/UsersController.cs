using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomsBookingAPI.Data;
using RoomsBookingAPI.Services;

namespace RoomsBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICrudServices<Users, int> _userServices;
        public UsersController(ICrudServices<Users, int> userService)
        {
            _userServices = userService;
        }
        [HttpGet("GetUser")]
        public ActionResult<List<Users>> GetAll() => _userServices.GetAll().ToList();

        [HttpGet("Id")]
        public ActionResult<Users> Get(int Id)
        {
            var user = _userServices.Get(Id);
            if (user == null) return NotFound();
            else return user;


        }
        [HttpPost("CreateUser")] // create a new user

        public IActionResult Create(Users user)  // the end user will pass this in the body of request 
        {
            if (ModelState.IsValid)
            {
                _userServices.Add(user);
                return CreatedAtAction(nameof(Create), new { Id = user.User_Id }, user);
            }
            return BadRequest();
        }

        [HttpPut("UpdateUser")] // update rooms in database 

        public IActionResult update(int id, Users user)
        {
            var existingUser = _userServices.Get(id);
            if (existingUser == null || existingUser.User_Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _userServices.Update(existingUser, user);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("DeleteUser/{Id}")] // Delete a room in the database 

        public IActionResult Delete(int Id) // for delete should just pass in the ID 
        {
            var room = _userServices.Get(Id);
            if (room == null) return NotFound();
            _userServices.Delete(Id);
            return NoContent();
        }

    }
}
