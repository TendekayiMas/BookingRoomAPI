using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomsBookingAPI.Data
{
    public class Users
    {
        [Key]
        public int User_Id { get; set; }

        public string UserName { get; set; }

        public string UserLastName { get; set; }


        
        public int RoomId { get; set; }
    }
}
