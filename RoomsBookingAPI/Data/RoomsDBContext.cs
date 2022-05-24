using Microsoft.EntityFrameworkCore;

namespace RoomsBookingAPI.Data
{
    public class RoomsDBContext : DbContext
    {
        public RoomsDBContext(DbContextOptions<RoomsDBContext> options) : base(options) // this class inherits from the base 
        {

        }

        public DbSet<TblRooms> tbl_Rooms { get; set; } // this is where we get our rooms table
        public DbSet<Users> tbl_users { get; set; } 
    }
}
