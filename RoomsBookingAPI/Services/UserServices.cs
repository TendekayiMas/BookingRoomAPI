using RoomsBookingAPI.Data;
using RoomsBookingAPI.Data.Repositories;

namespace RoomsBookingAPI.Services
{
    public class UserServices : ICrudServices<Users, int>
    {
        private readonly ICrudRepository<Users, int> _usersRepository;
        public UserServices(ICrudRepository<Users, int> usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public void Add(Users element)
        {
            _usersRepository.Add(element);
            _usersRepository.Save();
        }

        public void Delete(int id)
        {
            _usersRepository.Delete(id);
            _usersRepository.Save();
        }

        public Users Get(int id)
        {
            return _usersRepository.Get(id);
        }

        public IEnumerable<Users> GetAll()
        {
            return _usersRepository.GetAll();
        }

        public void Update(Users oldElement, Users newElement)
        {
            oldElement.UserName = newElement.UserName;
            oldElement.UserLastName = newElement.UserLastName;
            oldElement.RoomId = newElement.RoomId;
            oldElement.User_Id = newElement.User_Id;
            _usersRepository.Update(oldElement);
            _usersRepository.Save();
        }
    }
}
