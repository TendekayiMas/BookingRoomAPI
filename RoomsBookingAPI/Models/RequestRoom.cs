namespace RoomsBookingAPI.Models
{
    public class RequestRoom //users to request specific rooms available 
    {
        public int Id { get; set; } 

        public string? RoomType { get; set; }

        public bool RoomAvailability { get; set; }

        public int RoomPrice { get; set; }
    }
}
