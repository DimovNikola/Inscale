namespace BusinessLayer
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBaseService<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
    }
}
