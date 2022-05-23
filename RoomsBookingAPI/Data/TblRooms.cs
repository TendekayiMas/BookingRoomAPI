using System.ComponentModel.DataAnnotations;

namespace RoomsBookingAPI.Data
{
    public class TblRooms
    {
        [Key]
        public int Id { get; set; }

        public int RoomNumber { get; set; }

        public string? RoomType { get; set; }

        public bool RoomAvailability { get; set; }

        public int RoomPrice
        {
            get; set;
        }
    }
}
