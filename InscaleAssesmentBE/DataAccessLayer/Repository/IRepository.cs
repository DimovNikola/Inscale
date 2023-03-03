using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(object Id);
        Task<T> Insert(T entity);
        void Save();
    }
}
