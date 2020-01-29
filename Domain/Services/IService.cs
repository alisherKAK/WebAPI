using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface IService<TEntity, TDto, TResource, TResponse> where TDto : class where TResource : class where TEntity : class where TResponse : class, IResponse<TEntity>
    {
        IResponse<TEntity> Add(TDto item);
        IResponse<TEntity> Delete(TDto item);
        IResponse<TEntity> Delete(int? id);
        IResponse<TEntity> Update(TDto item);
        IEnumerable<TResource> GetAll();
        TResource Get(TDto item);
        TResource Get(int? id);
    }
}
