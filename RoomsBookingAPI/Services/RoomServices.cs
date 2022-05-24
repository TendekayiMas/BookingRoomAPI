using RoomsBookingAPI.Data;
using RoomsBookingAPI.Data.Repositories;

namespace RoomsBookingAPI.Services
{
    public class RoomServices : ICrudServices<TblRooms, int>
    {
        private readonly ICrudRepository<TblRooms, int> _roomsRepository;
        public RoomServices(ICrudRepository<TblRooms, int> roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }
        public void Add(TblRooms element)
        {
            _roomsRepository.Add(element);
            _roomsRepository.Save();
        }
        public void Delete(int id)
        {
            _roomsRepository.Delete(id);
            _roomsRepository.Save();
        }
        public TblRooms Get(int id)
        {
            return _roomsRepository.Get(id);
        }
        public IEnumerable<TblRooms> GetAll()
        {
            return _roomsRepository.GetAll();
        }
        public void Update(TblRooms old, TblRooms newT)
        {
            old.RoomNumber = newT.RoomNumber;
            old.RoomAvailability = newT.RoomAvailability;
            old.RoomPrice = newT.RoomPrice;
            old.RoomType = newT.RoomType;
            _roomsRepository.Update(old);
            _roomsRepository.Save();
        }
    }
}
