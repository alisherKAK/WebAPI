using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity, TDto> where TEntity : class where TDto : class
    {
        TEntity Add(TEntity item);
        TEntity Delete(TEntity item);
        TEntity Delete(int? id);
        TEntity Update(TEntity item);
        IEnumerable<TDto> GetAll();
        TDto Get(TEntity item);
        TDto Get(int? id);
    }
}
