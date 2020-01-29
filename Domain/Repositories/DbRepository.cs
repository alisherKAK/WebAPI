using AutoMapper;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Repositories
{
    public class DbRepository<TEntity, TDto> : IRepository<TEntity, TDto> where TEntity : class, IEntity where TDto : class
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;
        public DbRepository(DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TEntity Add(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            //_context.SaveChanges();

            return _context.Entry(item).Entity;
        }

        public TEntity Delete(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
            //_context.SaveChanges();

            return _context.Entry(item).Entity;

        }

        public TEntity Delete(int? id)
        {
            var item = _context.Set<TEntity>().FirstOrDefault(i => i.Id == id);
            return Delete(item);
        }

        public TDto Get(TEntity item)
        {
            return Get(item.Id);
        }

        public TDto Get(int? id)
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(i => i.Id == id);
            return _mapper.Map<TDto>(entity);
        }

        public IEnumerable<TDto> GetAll()
        {
            var entities = _context.Set<TEntity>().ToList();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public TEntity Update(TEntity item)
        {
            var oldItem = _context.Set<TEntity>().ToList().Where(i => i.Id == item.Id).FirstOrDefault();

            _context.Entry(oldItem).CurrentValues.SetValues(item);
            //_context.SaveChanges();

            return _context.Entry(item).Entity;
        }
    }
}
