using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Repositories
{
    public class DbRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _context;
        public DbRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var item = _context.Set<T>().FirstOrDefault(i => i.Id == id);
            Delete(item);
        }

        public T Get(T item)
        {
            return Get(item.Id);
        }

        public T Get(int? id)
        {
            return _context.Set<T>().FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T item)
        {
            var oldItem = Get(item.Id);

            _context.Entry(oldItem).CurrentValues.SetValues(item);
            _context.SaveChanges();
        }
    }
}
