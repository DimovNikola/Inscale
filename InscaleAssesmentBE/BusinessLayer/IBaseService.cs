using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBaseService<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
    }
}
