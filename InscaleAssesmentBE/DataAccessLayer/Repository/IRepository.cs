namespace DataAccessLayer.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int Id);
        Task<T> Insert(T entity);
        void Save();
    }
}
