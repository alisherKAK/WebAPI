using AutoMapper;
using Domain.Infrastructure;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Domain.Services
{
    public class Service<TEntity, TDto, TResource, TResponse> : IService<TEntity, TDto, TResource, TResponse> where TDto : class where TResource : class where TEntity : class where TResponse : class, IResponse<TEntity>
    {
        protected readonly IRepository<TEntity, TDto> _repository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        public Service(IRepository<TEntity, TDto> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IResponse<TEntity> Add(TDto item)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                var entity = _mapper.Map<TEntity>(item);
                entity = _repository.Add(entity);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();

                var response = Activator.CreateInstance(typeof(TResponse), entity) as TResponse;
                return response;
            }
            catch(Exception e)
            {
                _unitOfWork.RollbackTransaction();

                var response = Activator.CreateInstance(typeof(TResponse), e.Message) as TResponse;
                return response;
            }
        }

        public IResponse<TEntity> Delete(TDto item)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                var entity = _mapper.Map<TEntity>(item);
                entity = _repository.Delete(entity);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();

                var response = Activator.CreateInstance(typeof(TResponse), entity) as TResponse;
                return response;
            }
            catch(Exception e)
            {
                _unitOfWork.RollbackTransaction();

                var response = Activator.CreateInstance(typeof(TResponse), e.Message) as TResponse;
                return response;
            }
        }

        public IResponse<TEntity> Delete(int? id)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                var entity = _repository.Delete(id);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();

                var response = Activator.CreateInstance(typeof(TResponse), entity) as TResponse;
                return response;
            }
            catch(Exception e)
            {
                _unitOfWork.RollbackTransaction();

                var response = Activator.CreateInstance(typeof(TResponse), e.Message) as TResponse;
                return response;
            }
        }

        public TResource Get(TDto item)
        {
            var entity = _mapper.Map<TEntity>(item);
            var dto = _repository.Get(entity);
            var resource = _mapper.Map<TResource>(dto);
            return resource;
        }

        public TResource Get(int? id)
        {
            var dto = _repository.Get(id);
            var resource = _mapper.Map<TResource>(dto);
            return resource;
        }

        public IEnumerable<TResource> GetAll()
        {
            var dtos = _repository.GetAll();
            var resources = _mapper.Map<IEnumerable<TResource>>(dtos);
            return resources;
        }

        public IResponse<TEntity> Update(TDto item)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                var entity = _mapper.Map<TEntity>(item);
                entity = _repository.Update(entity);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();

                var response = Activator.CreateInstance(typeof(TResponse), entity) as TResponse;
                return response;
            }
            catch(Exception e)
            {
                _unitOfWork.RollbackTransaction();

                var response = Activator.CreateInstance(typeof(TResponse), e.Message) as TResponse;
                return response;
            }
        }
    }
}
