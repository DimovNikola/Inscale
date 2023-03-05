namespace BusinessLayer
{
    using DataAccessLayer.Repository;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<List<T>> GetAll() => await _repository.GetAll();

        public async Task<T> GetById(int id) => await _repository.GetById(id);

        public async Task<T> Insert(T entity) => await _repository.Insert(entity);
    }
}
