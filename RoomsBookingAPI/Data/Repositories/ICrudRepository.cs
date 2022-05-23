namespace RoomsBookingAPI.Data.Repositories
{
    public interface ICrudRepository<T,U>
    {
        // Implementing the crud functions for interface
        public IEnumerable<T> GetAll();
        public T Get(U id);
        public void Add(T element);
        public void Update(T element);
        public void Delete(U id);
        public bool Exists(U id);
        public bool Save();

    }
}
