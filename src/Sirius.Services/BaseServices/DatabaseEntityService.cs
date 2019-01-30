using Sirius.Core;
using Sirius.Core.Data;
using Sirius.Core.Entities;
using Sirius.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sirius.Services
{
    public class DatabaseEntityService<TEntity> : BaseService
        where TEntity : IEntity
    {
        protected readonly IRepository<TEntity> _ServiceRepository;
        protected readonly IAppLogger _Logger;

        public DatabaseEntityService(IRepository<TEntity> repository, IAppLogger logger)
            : base(logger)
        {
            _ServiceRepository = repository;
            _Logger = logger;
        }

        public virtual OperationResult<List<TEntity>> GetItems(Func<TEntity, bool> filter)
        {
            return Execute<List<TEntity>>(result =>
            { 
                result.Item = _ServiceRepository.Table.Where(filter).ToList();
            });
        }

        public OperationResult<TEntity> GetById(int id)
        {
            return Execute<TEntity>(result =>
            {
                result.Item = _ServiceRepository.GetById(id);
            });
        }
        public virtual OperationResult<TEntity> Insert(TEntity item)
        {
            return Execute<TEntity>(result =>
            {
                _ServiceRepository.Insert(item);
                result.Item = item;
            });
        }

        public virtual OperationResult<TEntity> Update(TEntity item)
        {
            return Execute<TEntity>(result =>
            {
                _ServiceRepository.Update(item);
                result.Item = item;
            });
        }

        public virtual OperationResult<TEntity> Delete(TEntity item)
        {
            return Execute<TEntity>(result =>
            {
                _ServiceRepository.Delete(item);
                result.Item = item;
            });
        }
    }
}
