using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        private DbSet<T> _table;

        public Repository(DataContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T?> GetById(object id)
        {
            if (id == null) throw new ArgumentNullException();

            var item = await _table.FindAsync(id);

            return item != null ? item : null;
        }

        public async Task<T> Insert(T entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
