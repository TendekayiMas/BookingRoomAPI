namespace RoomsBookingAPI.Data.Repositories
{
    public class UserRepository : ICrudRepository<Users, int>
    {
        private readonly RoomsDBContext _usersContext;
        public UserRepository(RoomsDBContext usersContext)
        {
            _usersContext = usersContext ?? throw new
             ArgumentNullException(nameof(usersContext));
        }
        public void Add(Users element)
        {
            _usersContext.tbl_users.Add(element);
        }

        public void Delete(int id)
        {
            var user = Get(id);
            if (user is not null) _usersContext.tbl_users.Remove(Get(id));
        }

        public bool Exists(int id)
        {
            return _usersContext.tbl_users.Any(u => u.User_Id == id);
        }

        public Users Get(int id)
        {
            return _usersContext.tbl_users.FirstOrDefault(u => u.User_Id == id);
        }

        public IEnumerable<Users> GetAll()
        {
            return _usersContext.tbl_users.ToList();
        }

        public bool Save()
        {
            return _usersContext.SaveChanges() > 0;
        }

        public void Update(Users element)
        {
            _usersContext.Update(element);

        }
    }
}



