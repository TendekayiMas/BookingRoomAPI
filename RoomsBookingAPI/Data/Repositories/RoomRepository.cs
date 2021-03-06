namespace RoomsBookingAPI.Data.Repositories
{
    public class RoomRepository : ICrudRepository<TblRooms, int>
    {
        private readonly RoomsDBContext _roomsDBContext;
        public RoomRepository(RoomsDBContext roomsDBContext)
        {
            _roomsDBContext = roomsDBContext ?? throw new
            ArgumentNullException(nameof(roomsDBContext));

        }

        public void Add(TblRooms element)
        {
            _roomsDBContext.tbl_Rooms.Add(element);
        }

        public void Delete(int id)
        {
            var rooms = Get(id);
            if (rooms is not null) _roomsDBContext.tbl_Rooms.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _roomsDBContext.tbl_Rooms.Any(u => u.Id == id);
        }
        public TblRooms Get(int id)
        {
            return _roomsDBContext.tbl_Rooms.FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<TblRooms> GetAll()
        {
            return _roomsDBContext.tbl_Rooms.ToList();
        }
            public bool Save()
        {
            return _roomsDBContext.SaveChanges() > 0;
        }
        public void Update(TblRooms element)
        {
            _roomsDBContext.Update(element);
        }
    }
}
